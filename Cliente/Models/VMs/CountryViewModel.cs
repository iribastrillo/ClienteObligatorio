namespace Cliente.Models.VMs
{
    public class CountryViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string isoAlfa3 { get; set; }
        public decimal gdp { get; set; }
        public decimal population { get; set; }
        public string Image { get; set; }
        public string Region { get; set; }
    }
}

// "id":6,"name":"Alemania","isoAlfa3":"ALE","gdp":51000,"population":83000000,"image":"ALE.png",
// "region":"Europa"},"name":"Alemania","phone":"490000000"
// ,"email":"alemania@seleccion.com","bettors":4500030