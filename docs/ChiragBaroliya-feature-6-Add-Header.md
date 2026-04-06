## 📅 Feature Release (ChiragBaroliya/feature/6-Add-Header) - 2026-04-06 11:44:50

## 🚀 Features Implemented
Cookie-based authentication has been added to the application.

## 🐛 Bug Fixes
The vendor user's password hashing has been updated for consistency, reducing potential authentication issues.

## 📂 Affected Modules / Layers
The following modules have been affected: 
- `EcommerceApp.Backend/Controllers/AuthController.cs`
- `EcommerceApp.Backend/Mock/MockUserStore.cs`
- `EcommerceApp.Backend/Program.cs`

## 🔧 Technical Changes (Detailed)
- `AuthController.cs`: Modified to use cookie authentication, added claims-based identity, and signed in with cookies.
- `MockUserStore.cs`: Updated password hashing for default users to ensure consistent hashing.
- `Program.cs`: Added services for cookie authentication.
- A new `_ViewStart.cshtml` file has been added to set the layout for all pages.

## ⚡ Impact
The changes enhance the application's security posture by introducing cookie-based authentication, improving password hashing, and setting a default layout for all pages.

