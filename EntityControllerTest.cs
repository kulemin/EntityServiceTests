using EntityService.Controllers;
using EntityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityServiceTests
{
    public class EntityControllerTest
    {
        private readonly EntityController _controller;
        private readonly IEntitiesService _service;
        public EntityControllerTest()
        {
            _service = new EntitiesServiceFake();
            _controller = new EntityController(_service);
        }
        [Fact]
        public void GetOk()
        {
            var result = _controller.Get("cfaa0d3f-7fea-4423-9f69-ebff826e2f89") as OkObjectResult;
            Assert.Equal("{\"Id\":\"cfaa0d3f-7fea-4423-9f69-ebff826e2f89\",\"OperationDate\":\"2023-01-01T00:00:00\",\"Amount\":19.2}", result.Value);
        }
        [Fact]
        public void GetNotFound()
        {
            var result = _controller.Get("cfaa0d3f-7fea-4423-9f69-ebff826e2f88") as BadRequestObjectResult;
            Assert.Equal("�������� � ������� Guid �� �������.", result.Value);
        }
        [Fact]
        public void GetErrorFormat()
        {
            var result = _controller.Get("cfaa0d3f") as BadRequestObjectResult;
            Assert.Equal("������� ������ ����� �������� ������ ��� �� �������� Guid.", result.Value);
        }
        [Fact]
        public void PostInsertOk()
        {
            var result = _controller.Insert("{\"id\":\"cfaa0d3f-7fea-4423-9f69-ebff826e2f88\",\"operationDate\":\"2023-01-01T00:00:00\",\"amount\":19.2}") as OkObjectResult;
            Assert.Equal("������� �������� � ������ cfaa0d3f-7fea-4423-9f69-ebff826e2f88", result.Value);
        }
        [Fact]
        public void PostUpdate()
        {
            var result = _controller.Insert("{\"id\":\"cfaa0d3f-7fea-4423-9f69-ebff826e2f90\",\"operationDate\":\"2023-01-01T00:00:00\",\"amount\":20.2}") as OkObjectResult;
            Assert.Equal("�������� � id cfaa0d3f-7fea-4423-9f69-ebff826e2f90 ��������", result.Value);
        }
        [Fact]
        public void PostParameterIsMissing()
        {
            var result = _controller.Insert("{\"operationDate\":\"2023-01-01T00:00:00\",\"amount\":20.2}") as BadRequestObjectResult;
            Assert.Equal("����������� �������� 'id' � �������\r\n", result.Value);
        }
        [Fact]
        public void PostParameterFormatError()
        {
            var result = _controller.Insert("{\"id\":\"cfaa0d3f-7fea-4423-9f69-ebff826e2f90\",\"operationDate\":\"2023-01-\",\"amount\":20.2}") as BadRequestObjectResult;
            Assert.Equal("���� 'operationDate' ����� �������� ������\r\n", result.Value);
        }
    }
}