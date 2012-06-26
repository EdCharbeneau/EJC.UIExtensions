using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using System.Reflection;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Web.Routing;

namespace EJC.Helpers
{
    /// <summary>
    /// DropDown list extenders
    /// </summary>
    public static class DropDownExtensions
    {
        public static MvcHtmlString CascadingDropDownListFor<TModel, TSource, TDestination>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TSource>> source, Expression<Func<TModel, TDestination>> destination, IEnumerable<SelectListItem> selectList, string optionLabel, string actionUrl, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata destinationMetadata = ModelMetadata.FromLambdaExpression(destination, htmlHelper.ViewData);

            string destinationHtmlFieldName = ExpressionHelper.GetExpressionText(destination);
            string resolvedLabelText = destinationMetadata.DisplayName ?? destinationMetadata.PropertyName ?? destinationHtmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return MvcHtmlString.Empty;
            }

            var destinationListId = TagBuilder.CreateSanitizedId(htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(destinationHtmlFieldName));
            htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();
            htmlAttributes.Add("data-cascade-parent-for", string.Format("#{0}", destinationListId));
            htmlAttributes.Add("data-action-url", actionUrl);

            if (string.IsNullOrEmpty(optionLabel))
                return htmlHelper.DropDownListFor(source, selectList, htmlAttributes);

            return htmlHelper.DropDownListFor(source, selectList, optionLabel, htmlAttributes);
        }

    }
}
