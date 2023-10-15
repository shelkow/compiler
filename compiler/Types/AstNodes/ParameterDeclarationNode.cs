﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using compiler.Types.Tokens.Enumerations;

namespace compiler.Types.AstNodes
{
    class ParameterDeclarationNode
    {
        public VariableType Type { get; private set; }
        public string Name { get; private set; }

        public ParameterDeclarationNode(VariableType type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}
