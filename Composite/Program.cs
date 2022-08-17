using Composite;

// 1st example
var drawing = new GraphicObject
{
    Name = "My drawing"
};

drawing.Children.Add(new Square{ Color = "Red" });
drawing.Children.Add(new Square { Color = "Yellow" });
var group = new GraphicObject();
group.Children.Add(new Square { Color = "Blue" });
group.Children.Add(new Square { Color = "Blue" });
drawing.Children.Add(group);
Console.WriteLine(drawing);

// 2nd example
var neuron1 = new Neuron();
var neuron2 = new Neuron();
var layer1 = new NeuronLayer(3);
var layer2 = new NeuronLayer(4);

neuron1.ConnectTo(neuron2);
neuron1.ConnectTo(layer1);
layer2.ConnectTo(neuron1);
layer1.ConnectTo(neuron2);
