using System.Text.RegularExpressions;

[System.Serializable]
public class VersionModel
{
    public string latestVersion;

    public string GetLatestVersion()
    {
        return latestVersion;
        //var strippedVersion = StripHTML(latestVersion);
        //strippedVersion = RemoveAllWhitespace(strippedVersion);
        //var splitedArray = strippedVersion.Split(':');
        //return splitedArray[splitedArray.Length - 1];
    }

    private static string StripHTML(string input)
    {
        return Regex.Replace(input, "<.*?>", string.Empty);
    }

    private static string RemoveAllWhitespace(string input)
    {
        return Regex.Replace(input, @"\s+", string.Empty);
    }
}
