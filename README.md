# Campus Cart – Students Marketplace 🛒

Campus Cart is a web application designed to help university students buy, sell, and trade used items safely and affordably. By providing a trusted platform tailored for campus communities, students can easily exchange textbooks, electronics, furniture, and school supplies.

---

## Key Features

### Core Functionality (Included)

* **User Authentication:** Secure registration and login systems powered by ASP.NET Core Identity.
* **Product Catalog:** Browse live marketplace items populated dynamically from the database.
* **Search & Discovery:** Filter items instantly by categories or search listings using specific keywords.
* **Listing Management (CRUD):** Sellers can create new listings, upload item photos, edit existing postings, or remove listings from their personal dashboard.
* **Shopping Cart System:** Buyers can add products to a running cart, adjust item quantities, and view real-time price summaries.
* **Secure Contact System:** Integrated "Contact Seller" forms enable safe peer-to-peer negotiation without exposing private student emails.
* **Responsive Layout:** A mobile-friendly user experience that scales seamlessly across smartphones, tablets, and desktops.

### Out of Scope for Phase 1

* Live payment processing gateway (Stripe, PayPal, mobile money) — *all transactions occur in person*.
* Live real-time chat with typing indicators.
* Bidding, auction, or AI recommendation algorithms.
* Location tracking and GPS mapping.

---

## 📊 Team Dependability & Connectivity Matrix

Because our features are tightly integrated within the Blazor architecture, our development tasks flow sequentially to avoid blocking team progression.

| Team Member | Core Focus | Direct Impact On... | Hand-off Deliverable |
| :--- | :--- | :--- | :--- |
| **Anderson Komi Havah** | Auth & DB Setup | ➡️ Nico, Stephen & Charles | Defines `ApplicationDbContext` and base User schemas to unlock data mapping. |
| **Faith Oluwatise Idowu** | UI & Layout | ➡️ Nico, Stephen & Charles | Establishes the global `site.css` and navbar layouts to ensure visual consistency. |
| **Nico Uro/Stephen Owino** | Marketplace CRUD | ➡️ Faith & Charles | Complete `Item.cs` and `ItemService` so cards can display data and items can enter the cart. |
| **Charles Kingsley Ajeigbe** | Cart & Support | ➡️ Whole Team | Hooks up interactive UI components, manages Git health, and runs QA testing. |

---

## 🛠️ Project Architecture & Dependencies

This platform is engineered using modern web technologies within the **.NET ecosystem**:

* **Framework:** ASP.NET Core 10.0 (Blazor WebAssembly / Server)
* **Database Layer:** Entity Framework Core (EF Core)
* **Storage Engines:** SQLite (Local Development) / SQL Server (Production)
* **Security:** ASP.NET Core Identity (Password Hashing & Authorizations)
* **Frontend Design:** Bootstrap v5.x & Custom CSS3

---

## 📂 Basic File Structure

```text
Campus-Cart-Student-Marketplace/
│
├── Data/
│   └── ApplicationDbContext.cs      # Database management context (Anderson)
│
├── Models/
│   ├── ApplicationUser.cs           # Extended user profile schema (Anderson)
│   ├── Item.cs                      # Marketplace product data blueprint (Nico/Stephen)
│   ├── Category.cs                  # Product taxonomy categories (Nico/Stephen)
│   ├── CartItem.cs                  # Shopping cart item structural layout (Charles)
│   └── Message.cs                   # Contact form message schema (Charles)
│
├── Services/
│   ├── ItemService.cs               # Fetches and manages catalog data rows (Nico/Stephen)
│   ├── CartService.cs               # In-memory and session cart logic operations (Charles)
│   └── MessageService.cs            # Routes and processes seller inquiries (Charles)
│
├── Pages/
│   ├── Home.razor                   # Promotional landing dashboard (Faith)
│   ├── Marketplace.razor            # Filterable product gallery interface (Faith/Nico)
│   ├── ItemDetails.razor            # Product deep-dive page (Team)
│   ├── CreateListing.razor          # Form for uploading new product items (Nico)
│   ├── EditListing.razor            # Form for altering existing listings (Nico)
│   ├── Cart.razor                   # Summary calculation page for buyers (Charles)
│   ├── ContactSeller.razor          # Validated inquiry mailer layout (Charles)
│   ├── Login.razor                  # Authentication sign-in form (Anderson)
│   └── Register.razor               # Authentication account registration (Anderson)
│
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor         # Structural foundation skeleton wrapper (Faith)
│   │   └── NavMenu.razor            # Top bar menu with active state counters (Faith)
│   └── Shared/
│       └── ProductCard.razor        # Reusable component for displaying an item (Faith)
│
├── wwwroot/
│   ├── css/
│   │   └── site.css                 # Custom site global style variables (Faith)
│   └── images/                      # Static assets and upload target directory
│
├── Program.cs                       # Application bootstrapper and Service Registration
└── README.md                        # Documentation overview (Charles/Stephen)

```

---

## ⚙️ Getting Started Locally

1. **Clone the repository:**

```bash
git clone [https://github.com/andersonhavah/Campus-Cart-Student-Marketplace.git](https://github.com/andersonhavah/Campus-Cart-Student-Marketplace.git)
cd Campus-Cart-Student-Marketplace

```

1. **Restore NuGet packages and project tools:**

```bash
dotnet restore

```

1. **Apply initial database migrations:**

```bash
dotnet ef database update

```

1. **Launch the local development server:**

```bash
dotnet watch

```

# Open your browser and point it to the designated localhost port (e.g., `http://localhost:5109`) to interact with the UI
---
