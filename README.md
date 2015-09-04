This project represents a C# example of consuming the FundsLibrary DataApi https://www.fundslibrary.co.uk/FundsLibrary.DataApi.WebApi
the documentation for the Api can be found here: https://www.fundslibrary.co.uk/FundsLibrary.DataApi.Web

In order to get this project running, you will require an Api Key from our customer service team. Once you have a key simply copy it into the Web.Config in the authorizationKey attribute shown below:

```
<fundslibraryApi url="http://www.fundslibrary.co.uk/FundsLibrary.DataApi.WebApi" authorizationKey="" />
```

The documentation which explains how our proxy classes have been generated can be located here: http://wp.sjkp.dk/generate-c-classes-from-odata-metadata/ 
with the Visual Studio Extension available here: https://visualstudiogallery.msdn.microsoft.com/9b786c0e-79d1-4a50-89a5-125e57475937