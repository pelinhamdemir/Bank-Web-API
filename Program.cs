using WebAPIproject.Data;
using WebAPIproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIproject.Interfaces;
using WebAPIproject.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebAPIproject.Service;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);


builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<AppUser,IdentityRole>(options =>{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
     options.Password.RequiredLength = 5;
}

)

.AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddAuthentication(options =>{

    options.DefaultAuthenticateScheme = 
    options.DefaultChallengeScheme = 
    options.DefaultForbidScheme = 
    options.DefaultScheme = 
    options.DefaultSignInScheme = 
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options=>{
     options.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuer=true,
        ValidIssuer=builder.Configuration["JWT:Issuer"],
        ValidateAudience=true,
        ValidAudience=builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]?? throw new ArgumentNullException("JWT:SigningKey"))
        )
    };
});



builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IBankerInfoRepository, BankerInfoRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ILoanPaymentRepository, LoanPaymentRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDBContext>();

    context.Database.Migrate();  // Apply any pending migrations
    
    if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

    if (!context.Stocks.Any())
    {
        var stocks = new List<Stock>
        {
            new Stock { Symbol = "AAPL", CompanyName = "Apple Inc.", Purchase = 145.09m, LastDiv = 0.82m, Industry = "Technology", MarketCap = 2400000000000 },
            new Stock { Symbol = "MSFT", CompanyName = "Microsoft Corporation", Purchase = 299.79m, LastDiv = 0.62m, Industry = "Technology", MarketCap = 2200000000000 },
            new Stock { Symbol = "GOOGL", CompanyName = "Alphabet Inc.", Purchase = 2801.12m, LastDiv = 0.0m, Industry = "Technology", MarketCap = 1900000000000 },
            new Stock { Symbol = "AMZN", CompanyName = "Amazon.com Inc.", Purchase = 3518.99m, LastDiv = 0.0m, Industry = "Consumer Discretionary", MarketCap = 1700000000000 },
            new Stock { Symbol = "FB", CompanyName = "Meta Platforms Inc.", Purchase = 355.64m, LastDiv = 0.0m, Industry = "Communication Services", MarketCap = 970000000000 },
            new Stock { Symbol = "TSLA", CompanyName = "Tesla Inc.", Purchase = 688.99m, LastDiv = 0.0m, Industry = "Consumer Discretionary", MarketCap = 800000000000 },
            new Stock { Symbol = "NVDA", CompanyName = "NVIDIA Corporation", Purchase = 194.78m, LastDiv = 0.16m, Industry = "Technology", MarketCap = 480000000000 },
            new Stock { Symbol = "PYPL", CompanyName = "PayPal Holdings Inc.", Purchase = 270.72m, LastDiv = 0.0m, Industry = "Information Technology", MarketCap = 320000000000 },
            new Stock { Symbol = "NFLX", CompanyName = "Netflix Inc.", Purchase = 538.73m, LastDiv = 0.0m, Industry = "Communication Services", MarketCap = 240000000000 },
            new Stock { Symbol = "ADBE", CompanyName = "Adobe Inc.", Purchase = 649.89m, LastDiv = 0.0m, Industry = "Technology", MarketCap = 320000000000 },
        };

        context.Stocks.AddRange(stocks);
       
    }
context.SaveChanges();
    if (!context.Comments.Any())
    {
        var comments = new List<Comment>
        {
            new Comment { Titile = "Great Stock", Content = "Apple is performing well!", CreatedOn = DateTime.Now, StockId = 1 },
            new Comment { Titile = "Solid Investment", Content = "Microsoft has great potential.", CreatedOn = DateTime.Now, StockId = 2 },
            new Comment { Titile = "Innovative", Content = "Alphabet continues to innovate.", CreatedOn = DateTime.Now, StockId = 3 },
            new Comment { Titile = "Growth Potential", Content = "Amazon has strong growth potential.", CreatedOn = DateTime.Now, StockId = 4 },
            new Comment { Titile = "Social Media Giant", Content = "Meta is leading in social media.", CreatedOn = DateTime.Now, StockId = 5 },
            new Comment { Titile = "Future of Cars", Content = "Tesla is the future of electric vehicles.", CreatedOn = DateTime.Now, StockId = 6 },
            new Comment { Titile = "Graphics Leader", Content = "NVIDIA is the leader in graphics cards.", CreatedOn = DateTime.Now, StockId = 7 },
            new Comment { Titile = "Payment Solutions", Content = "PayPal offers great payment solutions.", CreatedOn = DateTime.Now, StockId = 8 },
            new Comment { Titile = "Streaming King", Content = "Netflix is the king of streaming.", CreatedOn = DateTime.Now, StockId = 9 },
            new Comment { Titile = "Creative Software", Content = "Adobe provides essential creative tools.", CreatedOn = DateTime.Now, StockId = 10 },
        };

        context.Comments.AddRange(comments);
        context.SaveChanges();
    }

    if (!context.Accounts.Any())
    {
        var accounts = new List<Account>
        {
            new Account { CustomerId = 1, AccountType = "Savings", Balance = 10000 },
            new Account { CustomerId = 2, AccountType = "Checking", Balance = 5000 },
            new Account { CustomerId = 1, AccountType = "Savings", Balance = 15000 },
            new Account { CustomerId = 3, AccountType = "Investment", Balance = 25000 },
            new Account { CustomerId = 2, AccountType = "Checking", Balance = 7000 },
    
        };

        context.Accounts.AddRange(accounts);
        context.SaveChanges();
    }

    if (!context.Branches.Any())
    {
        var branches = new List<Branch>
        {
            new Branch { Name = "Main Branch", Assets = 1000000.00m, Address = "123 Main Street" },
            new Branch { Name = "Downtown Branch", Assets = 750000.50m, Address = "456 Center Avenue" },
            new Branch { Name = "Westside Branch", Assets = 500000.75m, Address = "789 West Boulevard" },
            new Branch { Name = "North Branch", Assets = 900000.25m, Address = "321 North Avenue" },
            new Branch { Name = "East Branch", Assets = 600000.80m, Address = "654 East Street" },
            new Branch { Name = "South Branch", Assets = 850000.30m, Address = "987 South Boulevard" }
        };

        context.Branches.AddRange(branches);
        context.SaveChanges();
    }

    if (!context.BankerInfos.Any())
    {
        var branches = context.Branches.ToList();

        if (branches.Any())
        {
            var bankerInfo = new List<BankerInfo>
            {
                new BankerInfo { Name = "John Doe", BranchId = branches[0].Id },
                new BankerInfo { Name = "Jane Smith", BranchId = branches[1].Id },
                new BankerInfo { Name = "Michael Brown", BranchId = branches[1].Id },
                new BankerInfo { Name = "Emily Davis", BranchId = branches[2].Id },
                new BankerInfo { Name = "David Wilson", BranchId = branches[2].Id }
            };

            context.BankerInfos.AddRange(bankerInfo);
        }
        context.SaveChanges();
    }

    if (!context.CreditCards.Any())
    {
        var creditCards = new List<CreditCard>
        {
            new CreditCard { CardLimit = 5000.00m, ExpiryDate = DateTime.Now.AddYears(3), CustomerId = 1, AccountId = 1 },
            new CreditCard { CardLimit = 10000.00m, ExpiryDate = DateTime.Now.AddYears(2), CustomerId = 2, AccountId = 2 },
            new CreditCard { CardLimit = 7500.00m, ExpiryDate = DateTime.Now.AddYears(4), CustomerId = 1, AccountId = 3 },
            new CreditCard { CardLimit = 8000.00m, ExpiryDate = DateTime.Now.AddYears(3), CustomerId = 3, AccountId = 4 },
            new CreditCard { CardLimit = 6000.00m, ExpiryDate = DateTime.Now.AddYears(2), CustomerId = 2, AccountId = 5 },
            new CreditCard { CardLimit = 9000.00m, ExpiryDate = DateTime.Now.AddYears(5), CustomerId = 3, AccountId = 6 }
        };

        context.CreditCards.AddRange(creditCards);
        context.SaveChanges();
    }

    if (!context.Customers.Any())
    {
        var customers = new List<Customer>
        {
            new Customer { Name = "John Doe", MobileNumber = "123-456-7890" },
            new Customer { Name = "Jane Smith", MobileNumber = "987-654-3210" },
            new Customer { Name = "Michael Johnson", MobileNumber = "111-222-3333" },
            new Customer { Name = "Emily Brown", MobileNumber = "444-555-6666" },
            new Customer { Name = "David Wilson", MobileNumber = "777-888-9999" },
            new Customer { Name = "Sarah Davis", MobileNumber = "555-444-3333" }
        };

        context.Customers.AddRange(customers);
        context.SaveChanges();
    }

    if (!context.Loans.Any())
    {
        var loans = new List<Loan>
        {
            new Loan { CustomerId = 1, IssuedAmount = 50000.00m, RemainingAmount = 25000.00m, BranchId = 1, AccountId = 1 },
            new Loan { CustomerId = 2, IssuedAmount = 30000.00m, RemainingAmount = 15000.00m, BranchId = 2, AccountId = 2 },
            new Loan { CustomerId = 3, IssuedAmount = 40000.00m, RemainingAmount = 20000.00m, BranchId = 3, AccountId = 3 },
            new Loan { CustomerId = 4, IssuedAmount = 25000.00m, RemainingAmount = 12500.00m, BranchId = 1, AccountId = 3 },
            new Loan { CustomerId = 5, IssuedAmount = 10000.00m, RemainingAmount = 5000.00m, BranchId = 2, AccountId = 2 }
        };

        context.Loans.AddRange(loans);
        context.SaveChanges();
    }

    if (!context.LoanPayments.Any())
    {
        var loans = context.Loans.ToList();

        if (loans.Any())
        {
            var loanPayments = new List<LoanPayment>
            {
                new LoanPayment { LoanId = loans[0].Id, Amount = 500.00m, Date = DateTime.Now.AddDays(-30) },
                new LoanPayment { LoanId = loans[1].Id, Amount = 300.00m, Date = DateTime.Now.AddDays(-15) },
                new LoanPayment { LoanId = loans[2].Id, Amount = 400.00m, Date = DateTime.Now.AddDays(-20) },
                new LoanPayment { LoanId = loans[0].Id, Amount = 600.00m, Date = DateTime.Now.AddDays(-10) },
                new LoanPayment { LoanId = loans[1].Id, Amount = 250.00m, Date = DateTime.Now.AddDays(-5) }
            };

            context.LoanPayments.AddRange(loanPayments);
        }
        context.SaveChanges();
    }

    if (!context.Transactions.Any())
    {
        var transactions = new List<Transaction>
        {
            new Transaction { AccountId = 1, Type = "Deposit", Amount = 1000.00m, Date = DateTime.Now.AddDays(-30) },
            new Transaction { AccountId = 2, Type = "Withdrawal", Amount = 500.00m, Date = DateTime.Now.AddDays(-20) },
            new Transaction { AccountId = 3, Type = "Deposit", Amount = 1500.00m, Date = DateTime.Now.AddDays(-15) },
            new Transaction { AccountId = 1, Type = "Withdrawal", Amount = 700.00m, Date = DateTime.Now.AddDays(-10) },
            new Transaction { AccountId = 2, Type = "Deposit", Amount = 2000.00m, Date = DateTime.Now.AddDays(-5) }
        };

        context.Transactions.AddRange(transactions);
    }

    context.SaveChanges();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
