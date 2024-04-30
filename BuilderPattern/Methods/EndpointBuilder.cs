using System.Text;

namespace BuilderPattern.Methods;

public class EndpointBuilder
{
    private readonly StringBuilder _sbUrl = new();
    private readonly StringBuilder _sbParams = new();
    private const char defaultDelimiter = '/';

    public string BaseUrl { get; set; }
    public EndpointBuilder()
    {

    }
    public EndpointBuilder(string baseUrl)
    {
        BaseUrl = baseUrl;
    }
    public EndpointBuilder Append(string value) //methodun class'ın kendisini return ettiğine dikkat edelim.
    {
        _sbUrl.Append(value);
        _sbUrl.Append(defaultDelimiter);
        return this;
    }
    public EndpointBuilder AppendParam(string name, string value)
    {
        _sbParams.AppendFormat("{0}={1}&", name, value);
        return this;
    }
    public string Build()
    {
        // ?? kontrolü 
        if (BaseUrl.EndsWith(defaultDelimiter))
            _sbUrl.Insert(0, BaseUrl);
        else
            _sbUrl.Insert(0, $"{BaseUrl}{defaultDelimiter}");

        var url = _sbUrl.ToString().Trim().TrimEnd('&');

        if (_sbParams.Length > 0)
        {
            string qParams = _sbParams.ToString().TrimEnd('&');
            url = _sbUrl.ToString().TrimEnd(defaultDelimiter).TrimEnd('?');
            url = $"{url}?{qParams}";
        }

        return url.TrimEnd(defaultDelimiter);
    }
}
