using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic;

public class Filter
{
    public string Field { get; set; }
    public string? Value { get; set; }
    /// <summary>
    /// in , contains etc.
    /// </summary>
    public string Operator { get; set; }
    /// <summary>
    /// and & , or | etc.
    /// </summary>
    public string? Logic { get; set; }

    public IEnumerable<Filter>? Filters { get; set; }

    public Filter()
    {
        Field = string.Empty;
        Operator = string.Empty;
    }

    public Filter(string field,string @operator)
    {
        Field = field;
        Operator = @operator;
    }
}
