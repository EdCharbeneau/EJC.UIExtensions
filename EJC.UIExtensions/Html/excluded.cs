using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJC.UIExtensions.Html
{
    //{
    //    //Output <input type="checkbox" name="{CheckBoxGroup}" value="{CheckBoxValue}" {checked} />
    //    //Get the metadata from the Lambda expression passed from the model & view data dictionary
    //    ModelMetadata optionValueMetadata = ModelMetadata.FromLambdaExpression(optionValue, html.ViewData);
    //    ModelMetadata selectedValuesMetadata = ModelMetadata.FromLambdaExpression(selectedValues, html.ViewData);

    //    //Get the checkbox value
    //    string value = optionValueMetadata.Model.ToString();

    //    //Get the model name from the expression
    //    string valueFor = ExpressionHelper.GetExpressionText(optionValue);

    //    //If the labelText is empty, return empty string
    //    if (string.IsNullOrEmpty(value))
    //    {
    //        return MvcHtmlString.Empty;
    //    }

    //    //Get selected items
    //    List<string> selections = (List<string>)selectedValuesMetadata.Model;

    //    //Begin building html
    //    TagBuilder tag = new TagBuilder("input"); // <input 
    //    tag.Attributes.Add("type", "checkbox"); // type="checkbox"
    //    tag.Attributes.Add("name", selectedValuesMetadata.PropertyName); // name={selectedValuesPropertyName}
    //    tag.Attributes.Add("value", value); // value="{value}"

    //    //See if this item is checked
    //    if (selections.Contains(value))
    //    {
    //        tag.Attributes.Add("checked", string.Empty);
    //    }

    //    //tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(valueFor)); // for="valueFor"
    //    tag.MergeAttributes(htmlAttributes); //Add attribut collection to element
    //    return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal)); //Render html
    //}
}
