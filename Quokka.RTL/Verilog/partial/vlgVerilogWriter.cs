using Quokka.RTL.Tools;
using Quokka.RTL.Verilog.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL.Verilog
{
    public class vlgVerilogWriter
    {
        public static void Write(
            vlgVisitorFactoryInterface visitorFactory,
            IndentedStringBuilder builder, 
            vlgFile file)
        {
            var visitor = visitorFactory.Resolve(file);
            visitor.Visit(file, builder);
        }

        public static string Write(vlgFile file)
        {
            var formatters = new vlgFormattersImplementation();
            var visitorFactory = new vlgVisitorFactoryImplementation(formatters);

            var builder = new IndentedStringBuilder();

            Write(visitorFactory, builder, file);

            return builder.ToString();
        }
    }
}
