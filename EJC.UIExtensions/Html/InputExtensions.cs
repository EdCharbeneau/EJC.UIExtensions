using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Routing;

namespace EJC.Helpers
{
    public static partial class InputExtensions
    {

        #region String Expression

        public static MvcHtmlString CheckBoxListItem(this HtmlHelper htmlHelper, string name, string value)
        {
            return CheckBoxListItem(htmlHelper, name, value, false, (object)null /* htmlAttributes */);
        }

        public static MvcHtmlString CheckBoxListItem(this HtmlHelper htmlHelper, string name, string value, bool isChecked)
        {
            return CheckBoxListItem(htmlHelper, name, value, isChecked, (object)null /* htmlAttributes */);
        }

        public static MvcHtmlString CheckBoxListItem(this HtmlHelper htmlHelper, string name, string value, bool isChecked, object htmlAttributes)
        {
            return CheckBoxListItem(htmlHelper, name, value, isChecked, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString CheckBoxListItem(this HtmlHelper htmlHelper, string name, string value, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            return CheckBoxListItemHelper(htmlHelper, null /* metadata */, name, value, isChecked, htmlAttributes);
        }

        #endregion

        #region Lambda Expression

        //List<string> overloads
        public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> optionValue, Expression<Func<TModel, List<string>>> selectedValues)
        {
            return CheckBoxListItemFor(html, optionValue, selectedValues, null /* htmlAttributes */);
        }

        public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> optionValue, Expression<Func<TModel, List<string>>> selectedValues, object htmlAttributes)
        {
            //Get the metadata from the Lambda expression passed from the model & view data dictionary
            ModelMetadata selectedValuesMetadata = ModelMetadata.FromLambdaExpression(selectedValues, html.ViewData);
            return CheckBoxListItemFor(html, optionValue, selectedValuesMetadata, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        //string[] overloads
        public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> optionValue, Expression<Func<TModel, string[]>> selectedValues)
        {

            return CheckBoxListItemFor(html, optionValue, selectedValues, null /* htmlAttributes */);
        }

        public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> optionValue, Expression<Func<TModel, string[]>> selectedValues, object htmlAttributes)
        {
            return CheckBoxListItemFor(html, optionValue, selectedValues, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> optionValue, Expression<Func<TModel, string[]>> selectedValues, IDictionary<string, object> htmlAttributes)
        {
            //Get the metadata from the Lambda expression passed from the model & view data dictionary
            ModelMetadata selectedValuesMetadata = ModelMetadata.FromLambdaExpression(selectedValues, html.ViewData);
            return CheckBoxListItemFor(html, optionValue, selectedValuesMetadata, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> optionValue, ModelMetadata metaData, IDictionary<string, object> htmlAttributes)
        {
            RouteValueDictionary attributes = htmlAttributes.ToRouteValueDictionary();

            if (optionValue == null)
            {
                throw new ArgumentNullException("expression");
            }

            //Get the checkbox name & value
            string name = metaData.PropertyName;
            string value = ModelMetadata.FromLambdaExpression(optionValue, html.ViewData).Model.ToString();


            //If the labelText is empty, return empty string
            if (string.IsNullOrEmpty(value))
            {
                return MvcHtmlString.Empty;
            }

            //Get selected items
            List<string> selections = (List<string>)metaData.Model;

            bool isChecked = false;
            //See if this item is checked
            if (selections.Contains(value))
            {
                isChecked = true;
            }

            return CheckBoxListItemHelper(html, metaData, name, value, isChecked, attributes);
        }
        #endregion

        private static MvcHtmlString CheckBoxListItemHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, string value, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            //Begin building html
            TagBuilder tag = new TagBuilder("input");   // <input 
            tag.Attributes.Add("type", "checkbox");     // type="checkbox"
            tag.Attributes.Add("name", fullName);       // name={selectedValuesPropertyName}
            tag.Attributes.Add("value", value);         // value="{value}"

            //See if this item is checked
            if (isChecked)
            {
                tag.Attributes.Add("checked", string.Empty);
            }

            tag.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));
            tag.MergeAttributes(htmlAttributes); //Add attribut collection to element
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal)); //Render html
        }


    }
}
