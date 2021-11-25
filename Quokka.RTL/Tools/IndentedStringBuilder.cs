using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Quokka.RTL.Tools
{
    public class IndentedStringBuilder
    {
        StringBuilder _builder = new StringBuilder();
        int _indentCounter = 0;
        string IndentText => string.Join("", Enumerable.Range(0, _indentCounter).Select(_ => "\t"));

        public IDisposable Indent()
        {
            _indentCounter++;

            return Disposable.Create(() => _indentCounter--);
        }

        public void AppendIndent()
        {
            _builder.Append(IndentText);
        }

        public void Append(string content)
        {
            _builder.Append(content);
        }

        public void AppendLine()
        {
            _builder.AppendLine();
        }

        public void AppendLine(string content)
        {
            var lines = content.Split('\n').Select(l => l.TrimEnd());

            foreach (var l in lines)
            {
                if (string.IsNullOrWhiteSpace(l))
                {
                    _builder.AppendLine();
                    continue;
                }

                _builder.AppendLine($"{IndentText}{l}");
            }
        }

        public void AppendUnindentedLine(string content)
        {
            var lines = content.Split('\n').Select(l => l.TrimEnd());

            foreach (var l in lines)
            {
                if (string.IsNullOrWhiteSpace(l))
                {
                    _builder.AppendLine();
                    continue;
                }

                _builder.AppendLine($"{l}");
            }
        }

        public void AppendUnindentedLines(IEnumerable<string> lines)
        {
            foreach (var l in lines)
            {
                if (string.IsNullOrWhiteSpace(l))
                {
                    _builder.AppendLine();
                    continue;
                }

                _builder.AppendLine($"{l}");
            }
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
