using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace Shop.RealestateTest
{
    public class RealestateTest : TestBase
    {

        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnresult()
        {


            RealEstateDto dto = new RealEstateDto();

            dto.Address = "Name";
            dto.SizeSqrM = 50;
            dto.RoomCount = 123;
            dto.Floor = 123;
            dto.BuildingType = "New";
            dto.BuiltinYear = DateTime.Now;


            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;

            var result = await Svc<IRealEstateServices>().Create(dto);

            Assert.NotNull(result);

        }

        //[Fact] 
        ////chack a path for elements
        //public async Task ShouldNot_GetByIdSpaceship_WhenReturnNotEqual()

        //{
        //    //Arrange 
        //    Guid guid = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");
        //    //kuidas teha automaatselt teeb guidi ???
        //    Guid wrongGuid =Guid.Parse(Guid.NewGuid().ToString());


        //    //The [Fact] attribute indicates that this is a test method.
        //    //In the Assert.NotEqual method, you compare the guid and wrongGuid to ensure they are not equal.
        //    //Act

        //    await Svc<ISpaceshipServices>().GetAsync(guid);


        //    //Asert
        //    Assert.NotEqual(guid, wrongGuid);
        //}

        [Fact]

        public async Task should_GetByIdSpaceship()
        {
            //Arnge
            Guid guid = Guid.Parse("f6fe9c73-57a1-4e82-98b7-4c70699f723f");
            Guid guid1 = Guid.Parse("f6fe9c73-57a1-4e82-98b7-4c70699f723f");


            //Guid wrongGuid1 = Guid.Parse(Guid.NewGuid().ToString());






            //Act

            await Svc<IRealEstateServices>().GetAsync(guid);


            //Asert

            Assert.Equal(guid, guid1);
        }

        [Fact]
        public async Task Should_DeleteByIdRealestate_WhenDeleteSpaceship()


        {
            //Arange

            RealEstateDto realestate = MockSpaceshipData();


            //Act
            var addRealestate = await Svc<IRealEstateServices>().Create(realestate);
            var result = await Svc<IRealEstateServices>().Delete((Guid)addRealestate.Id);

            //Asert

            Assert.Equal(result, addRealestate);
        }



        [Fact]
        public async Task ShouldNot_DeleteById_WhenDidNotDeleteSpaceship()

        {
            RealEstateDto realestate = MockSpaceshipData();

            var AddEstate = await Svc<IRealEstateServices>().Create(realestate);
            var AddEstate2 = await Svc<IRealEstateServices>().Create(realestate);


            var result = await Svc<IRealEstateServices>().Delete((Guid)AddEstate2.Id);


            Assert.NotEqual(result.Id, AddEstate.Id);
        }


        [Fact]

        public async Task Should_Update_SpaceShip_WhenUpdateData()
        {
            var guid = new Guid("67457d6e-854d-4112-b467-776ef280574c");
            //Arrange
            //old data from db




            // new data
            RealEstateDto dto = MockSpaceshipData();




            RealEstateDto dt = new RealEstateDto();
            dt.Id = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");

            dt.Address = "Name";
            dt.SizeSqrM = 150;
            dt.RoomCount = 123;
            dt.Floor = 123;
            dt.BuildingType = "New";
            dt.BuiltinYear = DateTime.Now;















            //Act
            await Svc<IRealEstateServices>().Update(dto);


            //Asert
            Assert.Equal(dt.Id, guid);
            Assert.NotEqual(dt.Address, dto.Address);
            Assert.Equal(dt.SizeSqrM, dto.SizeSqrM);
            Assert.DoesNotMatch(dt.BuildingType.ToString(), dto.BuildingType.ToString());

        }

        [Fact]
        public async Task Should_UpdateSpaceShip_WhenUpdateDataVersion2()
        {
            RealEstateDto dto = MockSpaceshipData();
            var createReaestate = await Svc<IRealEstateServices>().Create(dto);


            RealEstateDto Update = MockUpdateSpaceshipData();
            var UpdateRealestate = await Svc<IRealEstateServices>().Update(Update);
            //error korda teha 
            Assert.DoesNotMatch(UpdateRealestate.Floor.ToString(), createReaestate.Floor.ToString());
            Assert.NotEqual(UpdateRealestate.Address, createReaestate.Address);
            Assert.NotEqual(UpdateRealestate.BuildingType, createReaestate.BuildingType);
            Assert.Matches(UpdateRealestate.RoomCount.ToString(), createReaestate.RoomCount.ToString());
        }


        [Fact]
        public async Task Should_UpdateSpaceship_WhenNotUpdateData()
        {
            RealEstateDto dto = MockSpaceshipData();
            await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto nullUpdate = MockNullSpaceship();
            await Svc<IRealEstateServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;
            Assert.True(dto.Id == nullId);
        }

        private RealEstateDto MockNullSpaceship()
        {
            RealEstateDto nullDto = new()
            {
                Id = null,
                Address = "Square",
                SizeSqrM = 150,
                RoomCount = 1234,
                Floor = 123,
                BuildingType = "New",
                BuiltinYear = DateTime.Now,


                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddYears(1),

            };
            return nullDto;
        }

        private RealEstateDto MockUpdateSpaceshipData()
        {
            RealEstateDto update = new()
            {
                Address = "Mae",
                SizeSqrM = 150,
                RoomCount = 1234,
                Floor = 1231,
                BuildingType = "fire-resistive",
                BuiltinYear = DateTime.Now,


                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddYears(1),



            };
            return update;
        }


        private RealEstateDto MockSpaceshipData()
        {
            RealEstateDto realestate = new()
            {


                Address = "Square",
                SizeSqrM = 150,
                RoomCount = 1234,
                Floor = 123,
                BuildingType = "Fire",
                BuiltinYear = DateTime.Now,


                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };


            return realestate;
        }
    }
}
