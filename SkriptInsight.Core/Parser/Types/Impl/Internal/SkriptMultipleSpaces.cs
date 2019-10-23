using System;
using System.Text;
using SkriptInsight.Core.Extensions;
using SkriptInsight.Core.Parser.Expressions;

namespace SkriptInsight.Core.Parser.Types.Impl.Internal
{
    [InternalType]
    [TypeDescription("si_spaces")]
    public class SkriptMultipleSpaces : SkriptGenericType<string>
    {
        protected override string TryParse(ParseContext ctx)
        {
            var sb = new StringBuilder();
            foreach (var c in ctx)
            {
                if (!char.IsWhiteSpace(c)) break;
                sb.Append(c);
            }
            return sb.ToString().IsEmpty() ? null : sb.ToString();
        }

        public override string AsString(string obj)
        {
            return obj;
        }
    }
}