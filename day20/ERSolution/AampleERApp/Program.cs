
using AampleERApp.Model;

namespace SampleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Area area = new Area();
            //area.Area1 = "POPO";
            //area.Zipcode = "44332";
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            //context.Areas.Add(area);
            // select areas
            foreach (var a in context.Areas)
            {
                System.Console.WriteLine(a.Area1);
            }

            // find the areas by name
            var area1 = context.Areas.Find("POPO");
            System.Console.WriteLine(area1.Zipcode);


            var areas = context.Areas.ToList();
            var area = areas.SingleOrDefault(a => a.Area1 == "TTTT");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            area = areas.SingleOrDefault(a => a.Area1 == "HYHY");
            context.Areas.Remove(area);
            context.SaveChanges();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }
        }
    }
}
