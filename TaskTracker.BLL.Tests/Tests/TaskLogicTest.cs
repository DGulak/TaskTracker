using Microsoft.Extensions.Logging;
using TaskTracker.BLL.Contracts;
using TaskTracker.Infrastructures.Contracts;
using TaskTracker.Infrastructures.Entities;
using TaskTracker.Infrastructures.Enums;
using Task = TaskTracker.Infrastructures.Entities.Task;
using TaskStatus = TaskTracker.Infrastructures.Enums.TaskStatus;

namespace TaskTracker.BLL.Tests.Tests
{
    public class TaskLogicTest
    {
        [Fact]
        public void GetAll()
        {
            //Arrange
            var task1 = new Task()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                TaskStatus = TaskStatus.Active,
                Priority = 0,
                ProjectId = 0,
            };
            var task2 = new Task()
            {
                Id = 2,
                Name = "Test",
                Description = "Test",
                TaskStatus = TaskStatus.Active,
                Priority = 0,
                ProjectId = 0,
            };
            var task3 = new Task()
            {
                Id = 3,
                Name = "Test",
                Description = "Test",
                TaskStatus = TaskStatus.Active,
                Priority = 0,
                ProjectId = 0,
            };
            IEnumerable<Task> expected = new List<Task>()
            {
                task1,
                task2,
                task3
            };
            IQueryable<Task> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<TaskLogic>>();

            var RepositoryMock = new Mock<IRepository<Task>>();
            RepositoryMock.Setup(r => r.GetAll()).Returns(Qexpected);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Task>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            //Act
            ITaskLogic projectLogic = new TaskLogic(UnitOfWorkMock.Object, loggerMock.Object);
            IEnumerable<Task> actual = projectLogic.GetAll();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AssignTask()
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

            var task1 = new Task()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                TaskStatus = TaskStatus.Active,
                Priority = 0,
                ProjectId = 1,
            };

            var loggerMock = new Mock<ILogger<TaskLogic>>();

            var RepositoryMock = new Mock<IRepository<Task>>();
            RepositoryMock.Setup(r => r.GetById(task1.Id)).Returns(task1);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Task>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            //Act
            ITaskLogic projectLogic = new TaskLogic(UnitOfWorkMock.Object, loggerMock.Object);
            projectLogic.AssignTask(project2.Id, task1.Id);

            //Assert
            Assert.Equal(task1.ProjectId, project2.Id);

        }

        [Fact]
        public void Where()
        {
            //Arrange
            var task1 = new Task()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                TaskStatus = TaskStatus.Active,
                Priority = 0,
                ProjectId = 0,
            };
            var task2 = new Task()
            {
                Id = 2,
                Name = "Test",
                Description = "Test",
                TaskStatus = TaskStatus.Active,
                Priority = 0,
                ProjectId = 0,
            };
            var task3 = new Task()
            {
                Id = 3,
                Name = "Test",
                Description = "Test",
                TaskStatus = TaskStatus.Active,
                Priority = 0,
                ProjectId = 0,
            };
            IEnumerable<Task> expected = new List<Task>()
            {
                task1,
                task2,
                task3
            };
            IQueryable<Task> Qexpected = expected.AsQueryable();

            var loggerMock = new Mock<ILogger<TaskLogic>>();

            var RepositoryMock = new Mock<IRepository<Task>>();
            RepositoryMock.Setup(r => r.GetAll()).Returns(Qexpected);

            var UnitOfWorkMock = new Mock<IUnitOfWork<Task>>();
            UnitOfWorkMock.Setup(uow => uow.Repository).Returns(RepositoryMock.Object);

            //Act
            ITaskLogic projectLogic = new TaskLogic(UnitOfWorkMock.Object, loggerMock.Object);
            IEnumerable<Task> actual = projectLogic.Where(p => p.Id == task1.Id);

            //Assert
            Assert.Single(actual);
            Assert.Equal(task1, actual.First());
        }
    }
}
