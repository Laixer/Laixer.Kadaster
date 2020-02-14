using System.Linq;
using Xunit;

namespace Laixer.Kadaster.UnitTests
{
    public class BagRegistrarTest
    {
        [Fact]
        public void CreateBagRegister()
        {
            // Arrange
            var config = new KadasterConfig
            {
                AuthKey = "SOMETESTKEY"
            };

            // Act
            var bag = new KadasterBag(config);

            // Assert
            Assert.Equal(config, bag.Config);
        }

        [Fact]
        public void ValidateBagIdentifier()
        {
            // Arrange
            var bag = new Entities.BagId("1001200000066331");

            // Act & Assert
            Assert.Equal("1001200000066331", bag.ToString());
        }

        [Fact]
        public void GetPremiseById()
        {
            // Arrange
            var config = new KadasterConfig
            {
                AuthKey = "00000000-0000-0000-0000-00000000000"
            };
            var bag = new KadasterBag(config, new MockEndpointProcedure());
            var pservice = bag.PremiseService();

            // Act & Assert
            Assert.Equal("0703100000022427", pservice.GetById("0703100000022427").Value.Id);
        }

        [Fact]
        public void GetAllPremises()
        {
            // Arrange
            var config = new KadasterConfig
            {
                AuthKey = "00000000-0000-0000-0000-00000000000"
            };
            var bag = new KadasterBag(config, new MockEndpointProcedure());
            var pservice = bag.PremiseService();

            // Act & Assert
            //Assert.Equal(4, pservice.GetAll(25).Count());
            Assert.Equal("1895100000022868", pservice.GetAll(25).First().Value.Id);

        }

        [Fact]
        public void GetAllPremisesCheckMatchingPolygons()
        {
            // Arrange
            var config = new KadasterConfig
            {
                AuthKey = "00000000-0000-0000-0000-00000000000"
            };
            var bag = new KadasterBag(config, new MockEndpointProcedure());
            var pservice = bag.PremiseService();

            // Act & Assert
            foreach (var item in pservice.GetAll())
            {
                if (item.Value.Embed.Geometry.Type.ToUpperInvariant() == "POLYGON")
                {
                    var polyStart = item.Value.Embed.Geometry.Coordination.First().First();
                    var polyEnd = item.Value.Embed.Geometry.Coordination.First().Last();

                    Assert.Equal(polyStart[0], polyEnd[0]);
                    Assert.Equal(polyStart[1], polyEnd[1]);
                }
            }
        }

        #region FUTURE_TEST
        //var des = bag.DesignationService().GetById("0710200000164116");
        //var rr = des.ResidentialObject(bag);

        //var dservice = bag.DesignationService();
        //foreach (var item in dservice.GetAll())
        //{

        //}

        //await dservice.GetAll(postcode: "3123EB", houseNumber: 43);
        //dservice.GetById("0005200000035461");
        //await dservice.GetByIdAsync("0005200000035461").AddressObject();
        //await dservice.GetByIdAsync("0005200000035461").PublicSpace();



        //var obj = pservice.GetById(new Entities.BagId("0003100000118018"));

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
        #endregion
    }
}
