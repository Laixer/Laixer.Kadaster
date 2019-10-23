using System.Threading.Tasks;
using Xunit;

namespace Laixer.Kadaster.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var config = new KadasterConfig
            {
                
            };

            var bag = new KadasterBag(config);
            var r = bag.Config == config;

            var dservice = bag.DesignationService();
            foreach (var item in dservice.GetAll())
            {

            }
            //await dservice.GetAllAsync(postcode: "3123EB", houseNumber: 43);
            //await dservice.GetByIdAsync("0005200000035461");
            //await dservice.GetByIdAsync("0005200000035461").AddressObject();
            //await dservice.GetByIdAsync("0005200000035461").PublicSpace();



            //var pservice = bag.GetService(BagService.Premise);
            //await pservice.GetAllAsync();
            //await pservice.GetByIdAsync("0003100000118018");
            //await pservice.GetByIdAsync("0003100000118018").ResidentialObject();



            //var rservice = bag.GetService(BagService.ResidentialObject);
            //await rservice.GetAllAsync();
            //await rservice.GetByIdAsync("0003100000118018");
            //await rservice.GetByIdAsync("0003100000118018").Designation();



            //var puservice = bag.GetService(BagService.PublicSpace);
            //await puservice.GetAllAsync();
            //await puservice.GetByIdAsync("0003100000118018");
            //await puservice.GetByIdAsync("0003100000118018").City();



            //var cservice = bag.GetService(BagService.City);
            //List<City> cityList = await cservice.GetAllAsync() as List<City>;
            //var rr = cityList.Where(s => s.naam.ToLower() == "schiedam").FirstOrDefault();
            //await cservice.GetByIdAsync("0003100000118018");
        }
    }
}
