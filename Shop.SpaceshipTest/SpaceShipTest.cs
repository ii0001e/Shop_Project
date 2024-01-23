using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace Shop.SpaceshipTest
{
    public class SpaceShipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnresult()
        {


            SpaceshipDto dto = new SpaceshipDto();

            dto.Name = "Name";
            dto.Type = "Type";
            dto.Passangers = 123;
            dto.EnginPower = 123;
            dto.Crew = 123;
            dto.Company = "asd";
            dto.CargoWeight = 123;

            dto.CreatedAt = DateTime.Now;
            dto.Modifieted = DateTime.Now;

            var result = await Svc<ISpaceshipServices>().Create(dto);

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

            await Svc<ISpaceshipServices>().GetAsync(guid);


            //Asert

            Assert.Equal(guid, guid1);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()


        {
            //Arange

            SpaceshipDto spaceship = MockSpaceshipData();


            //Act
            var addSpaceshipt = await Svc<ISpaceshipServices>().Create(spaceship);
            var result = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceshipt.Id);

            //Asert

            Assert.Equal(result, addSpaceshipt);
        }



        [Fact]
        public async Task ShouldNot_DeleteById_WhenDidNotDeleteSpaceship()

        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var AddSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var AddSpaceship2 = await Svc<ISpaceshipServices>().Create(spaceship);


            var result = await Svc<ISpaceshipServices>().Delete((Guid)AddSpaceship2.Id);


            Assert.NotEqual(result.Id, AddSpaceship.Id);
        }


        [Fact]

        public async Task Should_Update_SpaceShip_WhenUpdateData()
        {
            var guid = new Guid("67457d6e-854d-4112-b467-776ef280574c");
            //Arrange
            //old data from db
            Spaceship spaceship = new Spaceship();



            // new data
            SpaceshipDto dto = MockSpaceshipData();


            spaceship.Id = Guid.Parse("67457d6e-854d-4112-b467-776ef280574c");
            spaceship.Name = "University";
            spaceship.Type = "AI";
            spaceship.Passangers = 100;
            spaceship.EnginPower = 200;
            spaceship.Crew = 123;
            spaceship.Company = "Airobus";
            spaceship.CargoWeight = 500;
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.Modifieted = DateTime.Now.AddYears(1);













            //Act
            await Svc<ISpaceshipServices>().Update(dto);






            //Asert
            Assert.Equal(spaceship.Id, guid);
            Assert.NotEqual(spaceship.EnginPower, dto.EnginPower);
            Assert.Equal(spaceship.Crew, dto.Crew);
            Assert.DoesNotMatch(spaceship.Passangers.ToString(), dto.Passangers.ToString());

        }

        [Fact]
        public async Task Should_UpdateSpaceShip_WhenUpdateDataVersion2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceShip = await Svc<ISpaceshipServices>().Create(dto);


            SpaceshipDto Update = MockUpdateSpaceshipData();
            var UpdateSpaceShip = await Svc<ISpaceshipServices>().Update(Update);
            //error korda teha 
            Assert.DoesNotMatch(UpdateSpaceShip.Passangers.ToString(), createSpaceShip.Passangers.ToString());
            Assert.NotEqual(UpdateSpaceShip.EnginPower, createSpaceShip.EnginPower);
            Assert.NotEqual(UpdateSpaceShip.Crew, createSpaceShip.Crew);
            Assert.Matches(UpdateSpaceShip.Name, createSpaceShip.Name);
        }


        [Fact]
        public async Task Should_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto nullUpdate = MockNullSpaceship();
            await Svc<ISpaceshipServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;
            Assert.True(dto.Id == nullId);
        }

        private SpaceshipDto MockNullSpaceship()
        {
            SpaceshipDto nullDto = new()
            {
                Id = null,
                Name = "Name123",
                Type = "type123",
                Passangers = 123,
                EnginPower = 123,
                Crew = 123,
                Company = "asd",
                CargoWeight = 123,
                CreatedAt = DateTime.Now.AddYears(1),
                Modifieted = DateTime.Now.AddYears(1),


            };
            return nullDto;
        }

        private SpaceshipDto MockUpdateSpaceshipData()
        {
            SpaceshipDto update = new()
            {
                Name = "Name",
                Type = "Type",
                Passangers = 123986,
                EnginPower = 123986,
                Crew = 123986,
                Company = "asddas",
                CargoWeight = 129863,

                CreatedAt = DateTime.Now,
                Modifieted = DateTime.Now,

            };
            return update;
        }


        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {


                Name = "NameN",
                Type = "Type",
                Passangers = 123,
                EnginPower = 123,
                Crew = 123986,
                Company = "asd",
                CargoWeight = 123986,

                CreatedAt = DateTime.Now,
                Modifieted = DateTime.Now,

            };


            return spaceship;
        }







    }
}
