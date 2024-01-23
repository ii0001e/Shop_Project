using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Xunit;

namespace Shop.KindergartenTest
{
    public class CarDataTest1 : TestBase
    {
        [Fact]
        public async Task ShouldNotAddEmptyKindergartenWhenReturnResult()
        {
            KinderGartenDto dto = new KinderGartenDto();

            dto.GroupName = "Targv22";
            dto.ChildrenCount = 10;
            dto.KindergartenName = "OnNineCloud";
            dto.Teacher = "Teacher";
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;


            var result = await Svc<IKindergartenServices>().Create(dto);

            Assert.NotNull(result);

        }

        [Fact]

        public async Task ShouldGetByIDKinderGarten()

        {
            //Arnge
            Guid guid = Guid.Parse("f6fe9c73-57a1-4e82-98b7-4c70699f723f");
            Guid guid1 = Guid.Parse("f6fe9c73-57a1-4e82-98b7-4c70699f723f");


            //Act

            await Svc<IKindergartenServices>().GetAsync(guid);


            Assert.Equal(guid, guid1);


        }


        [Fact]
        public async Task ShouldDeleteByIdKinderGartenWhenDeleteKinderGarten()
        {

            KinderGartenDto kindergaten = MockGartenData();

            var AddKinderGarten = await Svc<IKindergartenServices>().Create(kindergaten);

            var result = await Svc<IKindergartenServices>().Delete((Guid)AddKinderGarten.Id);


            Assert.Equal(result, AddKinderGarten);


        }

        [Fact]
        public async Task ShouldDeletebyIdWhenDidNotDeleteKinderGarten()
        {
            KinderGartenDto kindergarten = MockGartenData();

            var AddKinderGarten = await Svc<IKindergartenServices>().Create(kindergarten);

            var AddKinderGarten2 = await Svc<IKindergartenServices>().Create(kindergarten);

            var result = await Svc<IKindergartenServices>().Delete((Guid)AddKinderGarten2.Id);


            Assert.NotEqual(result.Id, AddKinderGarten.Id);


        }

        [Fact]
        public async Task ShouldUodateKinderGartenWhenUpdateData()
        {
            var guid = new Guid("6321b6c0-e9d0-4601-a960-7a244c87cddd");

            KinderGarten kindergarten = new KinderGarten();

            KinderGartenDto dto = MockGartenData();

            kindergarten.Id = Guid.Parse("6321b6c0-e9d0-4601-a960-7a244c87cddd");
            kindergarten.GroupName = "Targv22";
            kindergarten.ChildrenCount = 11;
            kindergarten.KindergartenName = "OnNineCloud";
            kindergarten.Teacher = "Teacher1";
            kindergarten.CreatedAt = DateTime.Now.AddYears(1);
            kindergarten.UpdatedAt = DateTime.Now.AddYears(1);



            //Act
            await Svc<IKindergartenServices>().Update(dto);


            Assert.Equal(kindergarten.Id, guid);
            Assert.NotEqual(kindergarten.ChildrenCount, dto.ChildrenCount);
            Assert.Equal(kindergarten.KindergartenName, dto.KindergartenName);
            Assert.DoesNotMatch(kindergarten.Teacher, dto.Teacher);






        }

        [Fact]

        public async Task ShouldUodateKinderGartenWhenUpdateDataVersion1()
        {
            KinderGartenDto dto = MockGartenData();


            var createKinderGarten = await Svc<IKindergartenServices>().Create(dto);

            KinderGartenDto Update = MockUpdateKinderGartenData();

            var UpdateKindergarten = await Svc<IKindergartenServices>().Update(Update);


            Assert.DoesNotMatch(UpdateKindergarten.ChildrenCount.ToString(), createKinderGarten.ChildrenCount.ToString());

            Assert.NotEqual(UpdateKindergarten.Teacher, createKinderGarten.Teacher);

            Assert.Matches(UpdateKindergarten.KindergartenName, createKinderGarten.KindergartenName);






        }
        [Fact]
        public async Task ShouldUpdateKinderGartenWhenNotUpdatedata()
        {
            KinderGartenDto dto = MockGartenData();
            await Svc<IKindergartenServices>().Create(dto);

            KinderGartenDto nullUpdate = MockZeroGartendata();
            await Svc<IKindergartenServices>().Update(nullUpdate);


            var NullId = nullUpdate.Id;
            Assert.True(dto.Id == NullId);

        }


        private KinderGartenDto MockZeroGartendata()
        {
            KinderGartenDto nullDto = new()
            {
                Id = null,
                GroupName = "Targv22",
                ChildrenCount = 10,
                KindergartenName = "OnNineCloud",
                Teacher = "Teacher1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,


            };

            return nullDto;
        }


        private KinderGartenDto MockGartenData()
        {
            KinderGartenDto kindergarten = new()
            {

                GroupName = "Targv22",
                ChildrenCount = 10,
                KindergartenName = "OnNineCloud",
                Teacher = "Teacher",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,


            };

            return kindergarten;




        }


        private KinderGartenDto MockUpdateKinderGartenData()
        {
            KinderGartenDto update = new()
            {

                GroupName = "Targv22",
                ChildrenCount = 11,
                KindergartenName = "OnNineCloud",
                Teacher = "Teacher",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,




            };

            return update;
        }









    }
}
