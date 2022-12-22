using Microsoft.Extensions.Logging;
using TaskTracker.BLL.Contracts;
using TaskTracker.Infrastructures.Contracts;
using TaskTracker.Infrastructures.Entities;
using TaskTracker.Infrastructures.Enums;
using TaskTracker.Infrastructures.Filters;

namespace TaskTracker.BLL.Tests.Tests
{
    public class ProjectLogicTest
    {
        #region GetAll() - Test
        [Fact]
        public void GetAll()
        {
            //Arrange
            var project1 = new Project()
            {
                Id = 1,
                Name = "Test",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project2 = new Project()
            {
                Id = 2,
                Name = "Test2",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project3 = new Project()
            {
                Id = 3,
                Name = "Test3",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            IEnumerable<Project> expected = new List<Project>()
            {
                project1,
                project2,
                project3
            };
            IQueryable<Project> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<ProjectLogic>>();

            var RepositoryMock = new Mock<IRepository<Project>>();
            RepositoryMock.Setup(r => r.GetAll()).Returns(Qexpected);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Project>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            //Act
            IProjectLogic projectLogic = new ProjectLogic(UnitOfWorkMock.Object, loggerMock.Object);
            IEnumerable<Project> actual = projectLogic.GetAll();

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetAllFilteredByName()
        {
            //Arrange
            var project1 = new Project()
            {
                Id = 1,
                Name = "Test",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project2 = new Project()
            {
                Id = 2,
                Name = "Test2",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project3 = new Project()
            {
                Id = 3,
                Name = "Test3",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            IEnumerable<Project> expected = new List<Project>()
            {
                project1,
                project2,
                project3
            };
            IQueryable<Project> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<ProjectLogic>>();

            var RepositoryMock = new Mock<IRepository<Project>>();
            RepositoryMock.Setup(r => r.GetAll()).Returns(Qexpected);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Project>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            var filter = new GetAllProjectsFilter()
            {
                Name = project1.Name
            };

            //Act
            IProjectLogic projectLogic = new ProjectLogic(UnitOfWorkMock.Object, loggerMock.Object);
            IEnumerable<Project> actual = projectLogic.GetAll(filter);

            //Assert
            Assert.Single(actual);
            Assert.Equal(project1, actual.First());
        }
        [Fact]
        public void GetAllFilteredByStartDate()
        {
            //Arrange
            var project1 = new Project()
            {
                Id = 1,
                Name = "Test",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project2 = new Project()
            {
                Id = 2,
                Name = "Test2",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project3 = new Project()
            {
                Id = 3,
                Name = "Test3",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            IEnumerable<Project> expected = new List<Project>()
            {
                project1,
                project2,
                project3
            };
            IQueryable<Project> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<ProjectLogic>>();

            var RepositoryMock = new Mock<IRepository<Project>>();
            RepositoryMock.Setup(r => r.GetAll()).Returns(Qexpected);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Project>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            var filter = new GetAllProjectsFilter()
            {
                StartDate = project1.StartDate
            };

            //Act
            IProjectLogic projectLogic = new ProjectLogic(UnitOfWorkMock.Object, loggerMock.Object);
            IEnumerable<Project> actual = projectLogic.GetAll(filter);

            //Assert
            Assert.Single(actual);
            Assert.Equal(project1, actual.First());
        }
        [Fact]
        public void GetAllFilteredByCompletionDate()
        {
            //Arrange
            var project1 = new Project()
            {
                Id = 1,
                Name = "Test",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now.AddDays(1.0),
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project2 = new Project()
            {
                Id = 2,
                Name = "Test2",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project3 = new Project()
            {
                Id = 3,
                Name = "Test3",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            IEnumerable<Project> expected = new List<Project>()
            {
                project1,
                project2,
                project3
            };
            IQueryable<Project> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<ProjectLogic>>();

            var RepositoryMock = new Mock<IRepository<Project>>();
            RepositoryMock.Setup(r => r.GetAll()).Returns(Qexpected);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Project>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            var filter = new GetAllProjectsFilter()
            {
                CompletionDate = project1.CompletionDate
            };

            //Act
            IProjectLogic projectLogic = new ProjectLogic(UnitOfWorkMock.Object, loggerMock.Object);
            IEnumerable<Project> actual = projectLogic.GetAll(filter);

            //Assert
            Assert.Single(actual);
            Assert.Equal(project1, actual.First());
        }
        [Fact]
        public void GetAllFilteredByPriority()
        {
            //Arrange
            var project1 = new Project()
            {
                Id = 1,
                Name = "Test",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 1
            };
            var project2 = new Project()
            {
                Id = 2,
                Name = "Test2",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project3 = new Project()
            {
                Id = 3,
                Name = "Test3",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            IEnumerable<Project> expected = new List<Project>()
            {
                project1,
                project2,
                project3
            };
            IQueryable<Project> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<ProjectLogic>>();

            var RepositoryMock = new Mock<IRepository<Project>>();
            RepositoryMock.Setup(r => r.GetAll()).Returns(Qexpected);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Project>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            var filter = new GetAllProjectsFilter()
            {
                Priority = project1.Priority
            };

            //Act
            IProjectLogic projectLogic = new ProjectLogic(UnitOfWorkMock.Object, loggerMock.Object);
            IEnumerable<Project> actual = projectLogic.GetAll(filter);

            //Assert
            Assert.Single(actual);
            Assert.Equal(project1, actual.First());
        }
        #endregion

        [Fact]
        public void GetByID()
        {
            //Arrange
            var project1 = new Project()
            {
                Id = 1,
                Name = "Test",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project2 = new Project()
            {
                Id = 2,
                Name = "Test2",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project3 = new Project()
            {
                Id = 3,
                Name = "Test3",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            IEnumerable<Project> expected = new List<Project>()
            {
                project1,
                project2,
                project3
            };
            IQueryable<Project> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<ProjectLogic>>();

            var testId = project1.Id;

            var RepositoryMock = new Mock<IRepository<Project>>();
            RepositoryMock.Setup(r => r.GetById(testId)).Returns(expected.FirstOrDefault(p => p.Id == testId));

            var UnitOfWorkMock = new Mock<IUnitOfWork<Project>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            //Act
            IProjectLogic projectLogic = new ProjectLogic(UnitOfWorkMock.Object, loggerMock.Object);
            Project actual = projectLogic.GetById(testId);

            //Assert
            Assert.Equal(testId, actual?.Id ?? 0);
        }
        [Fact]
        public void Where()
        {
            //Arrange
            var project1 = new Project()
            {
                Id = 1,
                Name = "Test",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 1
            };
            var project2 = new Project()
            {
                Id = 2,
                Name = "Test2",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            var project3 = new Project()
            {
                Id = 3,
                Name = "Test3",
                StartDate = DateTime.Now,
                CompletionDate = DateTime.Now,
                ProjectStatus = ProjectStatus.ToDo,
                Priority = 0
            };
            IEnumerable<Project> expected = new List<Project>()
            {
                project1,
                project2,
                project3
            };
            IQueryable<Project> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<ProjectLogic>>();

            var RepositoryMock = new Mock<IRepository<Project>>();
            RepositoryMock.Setup(r => r.GetAll()).Returns(Qexpected);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Project>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            //Act
            IProjectLogic projectLogic = new ProjectLogic(UnitOfWorkMock.Object, loggerMock.Object);
            IEnumerable<Project> actual = projectLogic.Where(p => p.Name == project1.Name);

            //Assert
            Assert.Single(actual);
            Assert.Equal(project1, actual.First());
        }


    }
}
