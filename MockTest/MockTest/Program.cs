// See https://aka.ms/new-console-template for more information
using MockTest;
using Moq;

Console.WriteLine("Hello, World!");

var mock = new Mock<ILovelyInterface>();
mock.Setup(m => m.LovelyMethod(0));
ILovelyInterface liobj = mock.Object;
liobj.LovelyMethod(0);

Console.WriteLine("Goodbye, World!");