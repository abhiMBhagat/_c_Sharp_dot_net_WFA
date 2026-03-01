# Karma's Kitchen POS (Windows Forms)

Karma's Kitchen POS is a simple desktop Point of Sale tool built with C# and Windows Forms.
It helps a restaurant operator:
- register a customer
- pick menu items
- create an order with size and quantity
- calculate subtotal
- generate and save a receipt as PDF

## Tech stack
- C#
- .NET 8 (`net8.0-windows`)
- Windows Forms

## Project structure
- `Program.cs` - app entry point, opens login form.
- `Form1.cs` / `Form1.Designer.cs` - login form (`KarmaRestaurant`).
- `Dashboard.cs` / `Dashboard.Designer.cs` - main POS screen and all business logic.
- `customer_details.txt` - stores last entered customer details.

## Login
Use these default credentials:
- Username: `abhi`
- Password: `password`

If credentials are wrong, app shows a "Login Failed" message.

## Main POS flow
After login, `Dashboard` opens with 4 tabs:

1. `New Customer`
- Enter customer name, phone, email, and address.
- Click `Enter` to validate and save details.
- Click `Clear` to clear customer fields.

Validation rules:
- Name: letters and spaces only, minimum 2 characters.
- Phone: exactly 10 digits.
- Email: basic email format check.
- Address: maximum 50 characters.

2. `Menu`
- Select items from menu combo boxes (wraps, bowls, salads, soups, desserts, kids meal, family feast, drinks, sides/sauces).
- Click `Add to Cart` to move selected items into order list.
- Click `Reset` to clear all menu selections.

3. `Take Order`
- Select an item from the list.
- Choose size:
  - Regular (x1.0)
  - Medium (x1.5)
  - Large (x2.0)
- Enter quantity.
- Click `Add Meal` to add line to final meal text area and recalculate subtotal.
- Click `Clear` to clear final meal text.
- Click `Proceed to Pay $$` to prepare receipt text.

4. `Payment Process`
- Review generated receipt text.
- Click `Print Receipt` to save receipt as a `.pdf` file using Save dialog.

## How subtotal is calculated
For each order line:
- extract base price from item text (example: `$14.45`)
- apply size multiplier (R/M/L)
- multiply by quantity
- add to subtotal

## How to run

### Option 1: Visual Studio
1. Open `Karma_Restaurant_app.sln`.
2. Build and run (`F5`).

### Option 2: .NET CLI (Windows)
1. Open terminal in project root.
2. Run:

```bash
dotnet restore
dotnet run
```

## Files generated at runtime
- `customer_details.txt` (in app working directory) when customer details are saved.
- `receipt.pdf` (or custom name/path) when receipt is exported.

## Current limitations
- Login is hardcoded (single username/password in source code).
- Data is stored in plain text files (no database).
- PDF generation is a basic custom implementation (single-page text layout).

## Notes
This project is suitable for learning/demo use of a WinForms POS workflow.
