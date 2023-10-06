using J2.API.Common;

using Newtonsoft.Json;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;


public class ResponseBase<TType, TClass>
{
    [JsonIgnore]
    public int Status { get; set; }
    public int ActionCode { get; set; }
    public string ActionMessage
    {
        get
        {
            Dic.TryGetValue(ActionCode, out string desc);
            return desc;
        }
    }
    public IEnumerable<string> ErrorMessages { get; set; }

    public TClass Data { get; set; }

    [JsonIgnore]
    public HttpStatusCode HttpStatusCode
    {
        get
        {
            HttpStatusCodes.TryGetValue(ActionCode, out HttpStatusCode httpStatusCode);
            return httpStatusCode;
        }
    }

    private static readonly Dictionary<int, string> Dic = new Dictionary<int, string>();
    private static readonly Dictionary<int, HttpStatusCode> HttpStatusCodes = new Dictionary<int, HttpStatusCode>();

    static ResponseBase()
    {
        var type = typeof(TType);
        var baseType = type.BaseType;
        var descData = type.GetFields().Select(p => new { p, attr = p.GetCustomAttribute<DescriptionAttribute>() })
                .Where(@t => @t.attr != null)
                .Select(@t => new { actionCode = @t.p.GetValue(null), actionMessage = @t.attr.Description }).ToList();
        var httpStatusData = type.GetFields().Select(p => new { p, attr = p.GetCustomAttribute<HttpStatusAttribute>() })
                .Where(@t => @t.attr != null)
                .Select(@t => new { actionCode = @t.p.GetValue(null), httpStatus = @t.attr.HttpStatus }).ToList();
        if (baseType != null)
        {
            descData.AddRange(baseType.GetFields().Select(p => new { p, attr = p.GetCustomAttribute<DescriptionAttribute>() })
                .Where(@t => @t.attr != null)
                .Select(@t => new { actionCode = @t.p.GetValue(null), actionMessage = @t.attr.Description }).ToList());
            httpStatusData.AddRange(baseType.GetFields().Select(p => new { p, attr = p.GetCustomAttribute<HttpStatusAttribute>() })
                .Where(@t => @t.attr != null)
                .Select(@t => new { actionCode = @t.p.GetValue(null), httpStatus = @t.attr.HttpStatus }).ToList());
        }
        //data.ForEach(p => { Dic.Add((int)p.Status, p.Desc); });            

        Dic.AddRange(descData.Select(i => new KeyValuePair<int, string>((int)i.actionCode, i.actionMessage)));
        HttpStatusCodes.AddRange(httpStatusData.Select(i => new KeyValuePair<int, HttpStatusCode>((int)i.actionCode, i.httpStatus)));
    }
}

public class ResponseBase<TType>
{
    [JsonIgnore]
    public int Status { get; set; }
    public int ActionCode { get; set; }
    public string ActionMessage
    {
        get
        {
            Dic.TryGetValue(ActionCode, out string desc);
            return desc;
        }
    }
    public IEnumerable<string> ErrorMessages { get; set; }

    [JsonIgnore]
    public HttpStatusCode HttpStatusCode
    {
        get
        {
            HttpStatusCodes.TryGetValue(ActionCode, out HttpStatusCode httpStatusCode);
            return httpStatusCode;
        }
    }

    private static readonly Dictionary<int, string> Dic = new Dictionary<int, string>();
    private static readonly Dictionary<int, HttpStatusCode> HttpStatusCodes = new Dictionary<int, HttpStatusCode>();

    static ResponseBase()
    {
        var type = typeof(TType);
        var baseType = type.BaseType;
        var descData = type.GetFields().Select(p => new { p, attr = p.GetCustomAttribute<DescriptionAttribute>() })
                .Where(@t => @t.attr != null)
                .Select(@t => new { actionCode = @t.p.GetValue(null), actionMessage = @t.attr.Description }).ToList();
        var httpStatusData = type.GetFields().Select(p => new { p, attr = p.GetCustomAttribute<HttpStatusAttribute>() })
                .Where(@t => @t.attr != null)
                .Select(@t => new { actionCode = @t.p.GetValue(null), httpStatus = @t.attr.HttpStatus }).ToList();
        if (baseType != null)
        {
            descData.AddRange(baseType.GetFields().Select(p => new { p, attr = p.GetCustomAttribute<DescriptionAttribute>() })
                .Where(@t => @t.attr != null)
                .Select(@t => new { actionCode = @t.p.GetValue(null), actionMessage = @t.attr.Description }).ToList());
            httpStatusData.AddRange(baseType.GetFields().Select(p => new { p, attr = p.GetCustomAttribute<HttpStatusAttribute>() })
                .Where(@t => @t.attr != null)
                .Select(@t => new { actionCode = @t.p.GetValue(null), httpStatus = @t.attr.HttpStatus }).ToList());
        }
        //data.ForEach(p => { Dic.Add((int)p.Status, p.Desc); });            

        Dic.AddRange(descData.Select(i => new KeyValuePair<int, string>((int)i.actionCode, i.actionMessage)));
        HttpStatusCodes.AddRange(httpStatusData.Select(i => new KeyValuePair<int, HttpStatusCode>((int)i.actionCode, i.httpStatus)));

    }
}
