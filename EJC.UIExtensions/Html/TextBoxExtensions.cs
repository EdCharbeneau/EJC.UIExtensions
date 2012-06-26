using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Routing;
using System.Web.Mvc.Html;

namespace EJC.Helpers
{
    public static partial class InputExtensions
    {
        public static MvcHtmlString WatermarkedTextBoxForTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            IDictionary<string, object> attributes = new Dictionary<string, object>();
            attributes.Add("placeholder", metadata.Watermark);
            return htmlHelper.TextBoxFor(expression, attributes);
        }

        public static MvcHtmlString WatermarkedTextBoxForTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) 
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            IDictionary<string,object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            attributes.Add("placeholder", metadata.Watermark);
            return htmlHelper.TextBoxFor(expression, attributes);
        }

        public static MvcHtmlString WatermarkedTextAreaForTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            IDictionary<string, object> attributes = new Dictionary<string, object>();
            attributes.Add("placeholder", metadata.Watermark);
            return htmlHelper.TextAreaFor(expression, attributes);
        }

        public static MvcHtmlString WatermarkedTextAreaForTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            attributes.Add("placeholder", metadata.Watermark);
            return htmlHelper.TextAreaFor(expression, attributes);
        }
    }
}
