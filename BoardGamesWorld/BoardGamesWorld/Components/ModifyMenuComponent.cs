﻿using Microsoft.AspNetCore.Mvc;

namespace BoardGamesWorld.Components
{
    public class ModifyMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
