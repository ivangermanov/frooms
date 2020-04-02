using Froom.Data.Entities;
using Froom.Data.Models.Rooms;
using Froom.Data.Repositories.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services;

namespace Froom.UnitTest.Service
{
    public class RoomServiceTests
    {
        private RoomService _sut;
        private Mock<IRoomRepository> _mockRoomRepository;

        [SetUp]
        public void Setup()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
        }

        //[Test]
        //public async Task AddAsync_UserHasAccess_VerifiesCorrectRoomIsAdded()
        //{
        //    // when roles are implemented - this test should check if the user can add rooms

        //    // Arrange
        //    var postRoomModel = new PostRoomModel()
        //    {
        //        Number = "40",
        //        Floor = 1,
        //        BuildingName = "R1",
        //        Capacity = 40,
        //        Points = new List<Point>()
        //        {
        //            new Point { X = 1, Y = 1 }
        //        }
        //    };

        //    _sut = new RoomService(_mockRoomRepository.Object);

        //    // Act
        //    await _sut.AddRoomAsync(postRoomModel);

        //    // Assert
        //    // Verifies the repository method was called with the correct object
        //    _mockRoomRepository.Verify(r => r.AddAsync(It.Is<Room>(r => r.Number == postRoomModel.Number
        //                                                          && r.Floor == postRoomModel.Floor
        //                                                          && r.BuildingName == postRoomModel.BuildingName
        //                                                          && r.Capacity == postRoomModel.Capacity
        //                                                          && r.Points == postRoomModel.Points)), Times.Once);
        //}
    }
}
