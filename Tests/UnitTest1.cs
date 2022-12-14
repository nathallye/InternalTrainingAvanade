using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        Mock<Data.Context.AvanadeInternalTrainingContext> _avanadeInternalTrainingContext;

        public UnitTest1() 
        {
            _avanadeInternalTrainingContext = new Mock<Data.Context.AvanadeInternalTrainingContext>();
        }

        [TestMethod]
        public void ListAllStudents()
        {
            #region [ CONFIGURACAO ]
            IQueryable<Data.Entities.StudentEntity> data = new List<Data.Entities.StudentEntity>
            {
                new Data.Entities.StudentEntity()
                {
                    Id = 1,
                    Name = "Paulo",
                    LastName = "Bacelar",
                    Document = "1123123",
                    Matriculation = "123123"
                },
                new Data.Entities.StudentEntity()
                {
                    Id = 2,
                    Name = "Luiz",
                    LastName = "Miguel",
                    Matriculation = "12",
                    Document = "31312312"
                }
            }.AsQueryable();

            var mockTable = new Mock<DbSet<Data.Entities.StudentEntity>>();

            mockTable.As<IQueryable<Data.Entities.StudentEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockTable.As<IQueryable<Data.Entities.StudentEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockTable.As<IQueryable<Data.Entities.StudentEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockTable.As<IQueryable<Data.Entities.StudentEntity>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            _avanadeInternalTrainingContext.Setup(x => x.Students).Returns(mockTable.Object);
            #endregion


            List<Data.Entities.StudentEntity> listStudents =
                _avanadeInternalTrainingContext.Object.Students.ToList();

            Assert.IsTrue(listStudents.Count() == 2);
            Assert.AreEqual(1, listStudents[0].Id);
        }

        /*
        [TestMethod]
        public void GelAllClassesController()
        {
            #region [ CONFIGURACAO ]

            IQueryable<Data.Entities.ClassEntity> data = new List<Data.Entities.ClassEntity>
            {
                new Data.Entities.ClassEntity()
                {
                    Id = 1,
                    Name = "C#",
                    Description = ""
                },
                new Data.Entities.ClassEntity()
                {
                    Id = 2,
                    Name = "Java",
                    Description = "Decola Dev Java"
                },
                new Data.Entities.ClassEntity()
                {
                    Id = 3,
                    Name = "API",
                    Description = "Decola Dev API"
                }
            }.AsQueryable();

            var mockTable = new Mock<DbSet<Data.Entities.ClassEntity>>();
            mockTable.As<IQueryable<Data.Entities.ClassEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockTable.As<IQueryable<Data.Entities.ClassEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockTable.As<IQueryable<Data.Entities.ClassEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockTable.As<IQueryable<Data.Entities.ClassEntity>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            _avanadeInternalTrainingContext.Setup(x => x.Classes).Returns(mockTable.Object);

            #endregion

            Data.Repository.ClassRepository classRepository
               = new Data.Repository.ClassRepository(_avanadeInternalTrainingContext.Object);

            AvanadeInternalTraining.Controllers.ClassesController classesController =
                new AvanadeInternalTraining.Controllers.ClassesController(classRepository);

            IActionResult actionResult = classesController.GetAll();

            var result = actionResult as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            List<Data.Dto.ClassDto> listResult =
                result.Value as List<Data.Dto.ClassDto>;

            Assert.IsNotNull(listResult);
            Assert.AreEqual(3, listResult.Count);
            Assert.AreEqual(2, listResult[1].Key);
        }

        [TestMethod]
        public void GelAllClassesController_Simple()
        {
            Mock<Data.Interfaces.IClassRepository> classRepository
                = new Mock<Data.Interfaces.IClassRepository>();

            AvanadeInternalTraining.Controllers.ClassesController classesController =
                new AvanadeInternalTraining.Controllers.ClassesController(classRepository.Object);

            classRepository.Setup(s => s.GetAll())
                .Returns(new List<Data.Dto.ClassDto>()
                {
                    new Data.Dto.ClassDto()
                    {
                        Key = 5,
                        Name = "F#"
                    },
                    new Data.Dto.ClassDto()
                    {
                        Key = 6,
                        Name = "Lambda"
                    }
                });

            IActionResult actionResult = classesController.GetAll();

            var result = actionResult as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            List<Data.Dto.ClassDto> listResult =
                result.Value as List<Data.Dto.ClassDto>;

            Assert.IsNotNull(listResult);
            Assert.AreEqual(2, listResult.Count);
            Assert.AreEqual(6, listResult[1].Key);
        }

        [TestMethod]
        public void GelAllClassesController_BadRequest()
        {
            Mock<Data.Interfaces.IClassRepository> classRepository
                = new Mock<Data.Interfaces.IClassRepository>();

            AvanadeInternalTraining.Controllers.ClassesController classesController =
                new AvanadeInternalTraining.Controllers.ClassesController(classRepository.Object);

            classRepository.Setup(s => s.GetAll())
                .Returns(new List<Data.Dto.ClassDto>()
                {
                });

            IActionResult actionResult = classesController.GetAll();

            var result = actionResult as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);

            string resultApi =
                result.Value as string;

            Assert.IsNotNull(resultApi);
            Assert.AreEqual("Sem elementos", resultApi);
        }

        [TestMethod]
        public void GelAllClassesController_BadRequestNulo()
        {
            Mock<Data.Interfaces.IClassRepository> classRepository
                = new Mock<Data.Interfaces.IClassRepository>();

            AvanadeInternalTraining.Controllers.ClassesController classesController =
                new AvanadeInternalTraining.Controllers.ClassesController(classRepository.Object);

            classRepository.Setup(s => s.GetAll())
                .Returns((List<Data.Dto.ClassDto>)null);

            IActionResult actionResult = classesController.GetAll();

            var result = actionResult as NoContentResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }
        */
    }
}