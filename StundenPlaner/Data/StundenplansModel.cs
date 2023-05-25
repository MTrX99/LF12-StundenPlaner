namespace StundenPlaner.Data
{
    using System.Collections.Generic;

    public class StundenplansModel
    {
        public List<TagInfo>? Wochenplan { get; set; }
    }

    public class TagInfo
    {
        public string? Tag { get; set; }
        public string? Stunde { get; set; }
        public string? Fach { get; set; }
        public string? Lehrer { get; set; }
    }
}
