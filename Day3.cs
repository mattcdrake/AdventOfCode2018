using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace Advent2018CS
{
    internal sealed class Day3 : Day
    {
        private int[,] _fabricModel;
        private List<FabricSpec> _fabricSpecs;

        public Day3()
        {
            InputLines = Helpers.ParseInputLines("input_data\\day3.txt");
            _fabricModel = new int[1000,1000];
            _fabricSpecs = new List<FabricSpec>();
            Solution1 = Solve1();
            Solution2 = Solve2();
        }

        protected override string Solve1()
        {
            // For each line in input: parse data -> fabric spec, add fabric spec to model
            foreach (var line in InputLines)
            {
                var curFabricSpec = ParseSpec(line);
                _fabricSpecs.Add(curFabricSpec);
                AddSpecToModel(curFabricSpec);
            }

            // Count number of square inches w/ 2 more claims
            var claimed = 0;

            for (var i = 0; i < _fabricModel.GetLength(0); i++)
            {
                for (var j = 0; j < _fabricModel.GetLength(1); j++)
                {
                    if (_fabricModel[i, j] >= 2)
                    {
                        claimed++;
                    }
                }
            }
            return claimed.ToString();
        }

        protected override string Solve2()
        {
            foreach (var spec in _fabricSpecs)
            {
                if (IsUnclaimed(spec))
                {
                    return spec.Id.ToString();
                }
            }
            return "Unable to find an unclaimed fabric spec.";
        }

        private void AddSpecToModel(FabricSpec spec)
        {
            for (var i = spec.LeftEdge; i < spec.Width + spec.LeftEdge; i++)
            {
                for (var j = spec.TopEdge; j < spec.Height + spec.TopEdge; j++)
                {
                    _fabricModel[i, j]++;
                }
            }
        }

        private bool IsUnclaimed(FabricSpec spec)
        {
            for (var i = spec.LeftEdge; i < spec.Width + spec.LeftEdge; i++)
            {
                for (var j = spec.TopEdge; j < spec.Height + spec.TopEdge; j++)
                {
                    if (_fabricModel[i, j] > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static FabricSpec ParseSpec(string input)
        {
            var inputParts = input.Split();
            var id = int.Parse(inputParts[0].Substring(1));

            // Split left/top position into components
            var edges = inputParts[2].Split(',');
            var leftEdge = int.Parse(edges[0]);
            var topEdge = int.Parse(edges[1].Substring(0, edges[1].Length - 1));

            // Split width/height into components
            var dims = inputParts[3].Split('x');
            var width = int.Parse(dims[0]);
            var height = int.Parse(dims[1]);

            return new FabricSpec(id, leftEdge, topEdge, width, height);
        }

        private struct FabricSpec
        {
            public readonly int Id, LeftEdge, TopEdge, Width, Height;

            public FabricSpec(int id, int leftEdge, int topEdge, int width, int height)
            {
                Id = id;
                LeftEdge = leftEdge;
                TopEdge = topEdge;
                Width = width;
                Height = height;
            }
        }
    }
}
