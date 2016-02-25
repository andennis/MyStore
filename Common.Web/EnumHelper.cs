using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Common.Web
{
    public static class EnumHelper
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<TEnum>() where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = Convert.ToInt32(x).ToString()
                });
        }

        public static SelectList ToSelectList<TEnum>(TEnum? selectedValue = null) where TEnum : struct
        {
            IEnumerable<SelectListItem> items = ToSelectListItems<TEnum>();
            string selectedValueStr = selectedValue.HasValue ? Convert.ToInt32(selectedValue).ToString() : null;
            return new SelectList(items, "Value", "Text", selectedValueStr);
        }

        public static IDictionary<string, int> ToDictionary<TEnum>() where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .ToDictionary(k => k.ToString(), v => Convert.ToInt32(v));
        }

    }
}
