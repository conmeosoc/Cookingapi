﻿using System;
using System.Collections.Generic;

namespace Cookapp_API.Data;

public partial class IngrePost
{
    public string RefPost { get; set; } = null!;

    public string RefIngredient { get; set; } = null!;

    public virtual Ingredient RefIngredientNavigation { get; set; } = null!;

    public virtual Recipepost RefPostNavigation { get; set; } = null!;
}
