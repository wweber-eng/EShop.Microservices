namespace ENGSOFT.EShop.Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);

    public class CreateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // Definir o endpoint de postagem HTTP usando Carter e o Nepster
            // Mapear a nossa solicitação para umn objeto de comando
            // Enviar o comando pelo Mediator
            // Enviar o resultado de voltapara o modelo de resposta

            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
                {
                    var command = request.Adapt<CreateProductCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<CreateProductResponse>();
                    return Results.Created($"/products/{response.Id}", response);

                })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .WithSummary("Creates a new product")
                .WithDescription("Creates a new product in the catalog.")
                .WithGroupName("Products")
                ;

        }
    }
}
