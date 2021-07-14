using NSubstitute;
using Pizza;
using PizzaApp;
using System;
using Xunit;

namespace PizzaTests
{
    public class CreateNewOrderCommandTests
    {
        private readonly IOrderRepository _orderRepository;
        private readonly CreateNewOrderCommand _command;

        public CreateNewOrderCommandTests()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            _command = new CreateNewOrderCommand(_orderRepository);
        }

        [Fact]
        public void Can_always_execute()
        {
            Assert.True(_command.CanExecute(new CreateNewOrderParams()));
        }

        [Fact]
        public void When_executed_new_order_is_created()
        {
            //arrange
            var exampleParams = new CreateNewOrderParams();
            
            //act
            var result = _command.Execute(exampleParams);
            
            //assert
            Assert.NotEqual(Guid.Empty, result);
            _orderRepository.Received(1).Create(Arg.Is<IOrder>(o=>o.Id == result));
        }
    }
}
