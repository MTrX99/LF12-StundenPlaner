using StundenPlanerDB.Models;

namespace StundenPlaner.Data
{
    public class BenutzerAnlegerModel
    {
        public int KlasseID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public bool LehrerOderSchüler {  get; set; }

        public string? infos { get; set; }

        public void legeEnität()
        {
            using (SP_Context context = new SP_Context())
            {
                //if (LehrerOderSchüler) // false=>Lehrer true=> Schüler
                //{
                    var schüler = new Schüler { Name= Name, KlasseId= KlasseID };
                    context.Schüler.Add(schüler);
                    context.SaveChanges();
                //}
            }
        }
        public void holeDieInfos()
        {
            using (SP_Context context = new())
            {
                foreach (var item in context.Schüler)
                {
                    infos += item.ToString();
                }
            }
        }
    }
}
