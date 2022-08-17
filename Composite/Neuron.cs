using System.Collections;
using System.Collections.ObjectModel;

namespace Composite;

public class Neuron : IEnumerable<Neuron>
{
    public List<Neuron> In, Out;

    // moved to extension method
    //public void ConnectTo(Neuron other)
    //{
    //    Out.Add(other);
    //    other.In.Add(this);
    //}

    public IEnumerator<Neuron> GetEnumerator()
    {
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class NeuronLayer : Collection<Neuron>
{
    public NeuronLayer(int count)
    {
        while (count-- > 0)
        {
            Add(new Neuron());
        }
    }
}

public static class ExtensionMethods
{
    public static void ConnectTo(
        this IEnumerable<Neuron> self,
        IEnumerable<Neuron> other)
    {
        if (ReferenceEquals(self, other))
        {
            return;
        }

        foreach (var from in self)
        {
            foreach (var to in other)
            {
                from.Out.Add(to);
                to.In.Add(from);
            }
        }
    }
}
