using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliriumSpawnerHighlight
{

    public class DeliriumSpawnerSettings : ISettings
    {
        public ToggleNode Enable { get; set; }


        [Menu("Good Spawner", 0)]
        public Spawner GoodSpawner { get; set; }

        [Menu("Bad Spawner", 1)]
        public Spawner BadSpawner { get; set; }

        [Menu("Unknown Spawner", 2)]
        public Spawner UnknownSpawner { get; set; }


        public DeliriumSpawnerSettings()
        {
            Enable = new ToggleNode(false);

            GoodSpawner = new Spawner(
                new ToggleNode(true),
                new ColorNode(Color.Green),
                new RangeNode<int>(15, 1, 50)
                );

            BadSpawner = new Spawner(
                new ToggleNode(true),
                new ColorNode(Color.Red),
                new RangeNode<int>(15, 1, 50)
                );

            UnknownSpawner = new Spawner(
                new ToggleNode(false),
                new ColorNode(Color.Yellow),
                new RangeNode<int>(15, 1, 50)
            );
        }
    }

    public class Spawner : ISettings
    {
        [Menu("Enable", 10)]
        public ToggleNode Enable { get; set; }
        [Menu("Color", 11)]
        public ColorNode Color { get; set; }
        [Menu("Size", 12)]
        public RangeNode<int> Size { get; set; }

        public Spawner(ToggleNode draw, ColorNode color, RangeNode<int> size)
        {
            Enable = draw ?? throw new ArgumentNullException(nameof(draw));
            Color = color ?? throw new ArgumentNullException(nameof(color));
            Size = size ?? throw new ArgumentNullException(nameof(size));
        }
    }
}
