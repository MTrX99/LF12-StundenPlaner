namespace StundenPlaner.Data
{
    using Azure;
    using StundenPlanerDB.Models;
    using System.Collections.Generic;
    using System.Globalization;

    public class StundenplansModel
    {
        public List<TagInfo>? Wochenplan { get; set; }
        public SP_Context context { get; set; }
        public StundenplansModel(SP_Context sP_Context)
        {
            context = sP_Context;
        }

        public void ladeStunden()
        {
            DayOfWeek[] werktagen = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

            CultureInfo germanCulture = new CultureInfo("de-DE");
            List<Stunde>? Stunden = new();
            
            using (context)
            {
                var DBstunden = (from l in context.Lehrer
                               join s in context.Schulfach on l.SchulfachId equals s.Id
                               select new { Fach = s.Name, Lehrer = l.Name }
                               ).ToList();

                foreach (var stunde in DBstunden)
                {
                    Stunden.Add(new(stunde.Fach, stunde.Lehrer));
                }
            }


            

            Wochenplan = new();


            foreach (DayOfWeek werktag in werktagen)
            {
                string werktagName = germanCulture.DateTimeFormat.GetDayName(werktag);
                Wochenplan.Add(new(werktagName,Stunden));
            }
        }
    }
  
    public class TagInfo
    {
        public string? Tag { get; set; }
        public List<Stunde>? Stunden { get; set; }

        public TagInfo(string tag, List<Stunde> stunden)
        {
            Tag = tag;
            Stunden = stunden;
        }
    }
   

    public class Stunde
    {
        public string? Fach { get; set; }
        public string? Lehrer { get; set; }

        public Stunde(string fach, string lehrer)
        {
            Fach = fach;
            Lehrer = lehrer;
        }
    }
}