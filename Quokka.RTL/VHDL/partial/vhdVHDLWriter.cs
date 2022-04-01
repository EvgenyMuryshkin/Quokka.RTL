using Quokka.RTL.Tools;
using Quokka.RTL.VHDL.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL.VHDL
{

    public class vhdVHDLWriter
    {
        public static void WriteObject(
            vhdVisitorFactoryInterface visitorFactory,
            IndentedStringBuilder builder,
            vhdAbstractObject obj)
        {
            var visitor = visitorFactory.Resolve(obj);
            visitor.Visit(obj, builder);
        }

        public static string WriteObject(vhdAbstractObject obj)
        {
            var formatters = new vhdFormattersImplementation();
            var visitorFactory = new vhdVisitorFactoryImplementation(formatters);

            var builder = new IndentedStringBuilder();

            WriteObject(visitorFactory, builder, obj);

            return builder.ToString();
        }


        public static void Write(
            vhdVisitorFactoryInterface visitorFactory,
            IndentedStringBuilder builder, 
            vhdFile file)
        {
            var visitor = visitorFactory.Resolve(file);
            visitor.Visit(file, builder);
        }

        public static string Write(vhdFile file)
        {
            var formatters = new vhdFormattersImplementation();
            var visitorFactory = new vhdVisitorFactoryImplementation(formatters);

            var builder = new IndentedStringBuilder();

            Write(visitorFactory, builder, file);

            return builder.ToString();
        }
    }
}
