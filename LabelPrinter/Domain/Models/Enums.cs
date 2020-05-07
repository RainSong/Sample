using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelPrinter.Domain.Models
{
    public enum LabelType
    {
        Unknow = 0,
        LotLabel = 1,
        PassLabel = 2,
        CircuitLabel = 3,
        BoxLabel = 4
    }

    public enum LabelStyleItemType
    {
        Unknown = 0,
        String = 1,
        BarCode = 2,
        DataMatrix = 3,
        QRCode = 4,
        Line = 5
    }

    public enum LabelStyleItemValueType
    {
        Unknown = 0,
        Input = 1,
        Compute = 2,
        Fixed = 3
    }

    public enum LabelStyleItemPropertyType
    {
        Unknown = 0,
        Width = 100,
        Height = 101,
        LocationX = 200,
        LocationY = 201,
        Location2X = 202,
        Location2Y = 203,
        FontName = 300,
        FontSize = 301,
        FontStyle = 302,
        PenStyle = 400,
        Alignment = 500,
        RotationAngle = 600
    }

    public enum LabelStyleItemPropertyValueType
    {
        Unknown = 0,
        Fixed = 1,
        Compute = 2
    }

    public enum ScriptRelatedType
    {
        Unknown = 0,
        LabelStyleItem = 101,
        LabelStyleItemProperty = 102

    }
}
