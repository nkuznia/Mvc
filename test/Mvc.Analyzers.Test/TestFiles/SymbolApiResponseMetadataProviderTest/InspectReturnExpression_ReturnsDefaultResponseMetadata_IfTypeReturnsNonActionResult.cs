namespace Microsoft.AspNetCore.Mvc.Analyzers
{
    public class InspectReturnExpression_ReturnsDefaultResponseMetadata_IfTypeReturnsNonActionResult : ControllerBase
    {
        public InspectReturnExpression_ReturnsDefaultResponseMetadata_IfTypeReturnsNonActionResultModel Get()
        {
            return new InspectReturnExpression_ReturnsDefaultResponseMetadata_IfTypeReturnsNonActionResultModel();
        }
    }

    public class InspectReturnExpression_ReturnsDefaultResponseMetadata_IfTypeReturnsNonActionResultModel { }
}
