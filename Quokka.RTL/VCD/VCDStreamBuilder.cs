﻿using Quokka.RTL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Quokka.VCD
{
    public class VCDStreamBuilder
    {
        StringWriter _sb;
        Stack<VCDSignalsSnapshot> _scopes = new Stack<VCDSignalsSnapshot>();

        public VCDStreamBuilder(StringWriter sb)
        {
            _sb = sb;
        }

        protected string Underscored(string value)
        {
            return value.Replace(" ", "_");
        }

        protected void SectionStart(string section)
        {
            _sb.WriteLine($"${section}");
        }

        protected void SectionEnd()
        {
            _sb.WriteLine($"$end");
        }

        protected void Line(string value)
        {
            _sb.WriteLine(value);
        }

        protected void Section(string section, string value = "")
        {
            SectionStart(section);

            if (!string.IsNullOrWhiteSpace(value))
                Line(value);

            SectionEnd();
        }

        protected void InlineSection(string section, string value)
        {
            Line($"${section} {value} $end");
        }

        public void Date(DateTime value)
        {
            Section("date", $"{value.ToLongDateString()} {value.ToLongTimeString()}");
        }

        public void Version(string version)
        {
            Section("version", version);
        }

        public void Timescale(string version)
        {
            Section("timescale", version);
        }

        public void EndDefinitions()
        {
            Section("enddefinitions", "");
        }

        protected void PushScope(VCDSignalsSnapshot scope)
        {
            _scopes.Push(scope);
        }

        protected void PopScope()
        {
            _scopes.Pop();
        }

        protected void BeginScope(VCDSignalsSnapshot scope)
        {
            PushScope(scope);
            var name = Underscored(scope.Name);
            InlineSection("scope module", name);
        }

        protected void EndScope()
        {
            Section("upscope");
            PopScope();
        }

        protected string ScopeName => VCDTools.FormatScopePrefix(_scopes);

        protected void Variable(VCDVariableType type, string name, int size)
        {
            name = Underscored(name);
            var identifier = $"{ScopeName}{name}";
            var reference = $"{ScopeName}" + (size > 1 ? $"{name}[{size - 1}:0]" : name);
            InlineSection("var", $"{type.ToString().ToLower()} {size} {identifier} {reference}");
        }

        public void Snapshot(IEnumerable<VCDVariable> snapshot)
        {
            foreach (var variable in snapshot)
            {
                var value = VCDInteraction.VCDValue(variable);

                if (!string.IsNullOrWhiteSpace(value))
                {
                    SetValue(variable.Type, variable.Size, variable.Name, value);
                }
            }
        }

        public void Snapshot(VCDSignalsSnapshot snapshot)
        {
            if (snapshot == null)
                return;

            PushScope(snapshot);

            Snapshot(snapshot.Variables);

            foreach (var child in snapshot.Scopes)
            {
                Snapshot(child);
            }

            PopScope();
        }

        public void Scope(VCDSignalsSnapshot scope)
        {
            BeginScope(scope);

            foreach (var s in scope.Scopes)
            {
                Scope(s);
            }

            foreach (var v in scope.Variables)
            {
                Variable(v.Type, v.Name, v.Size);
            }

            EndScope();
        }

        public void SetTime(int value)
        {
            Line($"#{value}");
        }

        public void SetValue(VCDVariableType type, int size, string signal, string value)
        {
            switch (type)
            {
                case VCDVariableType.String:
                    Line($"s{value} {ScopeName}{signal}");
                    break;
                case VCDVariableType.Wire:
                    if (size == 1)
                        Line($"{value}{ScopeName}{signal}");
                    else
                        Line($"b{value} {ScopeName}{signal}");
                    break;
            }
        }
    }
}
