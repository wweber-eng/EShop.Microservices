namespace ENGSOFT.EShop.Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Descrption, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // OK - Criação da logica de criação de produtos
            // OK - Criar a entidade de produto a partir do objeto de comando
            // TODO - Salvar no banco dee dados
            // OK - Retornar o resultado com o Id do produto criado

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                description = command.Descrption,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
