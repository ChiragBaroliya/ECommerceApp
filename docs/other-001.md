## 📅 Other Release (master) - 2026-03-31 12:54:34

## 🚀 Features Implemented
No new features identified from diff

## 🐛 Bug Fixes
Bug fix: ValidationAntiForgeryToken attribute moved to correct position for correct validation

## 📂 Affected Modules / Layers
EcommerceApp.Backend/Pages/Products/Create.cshtml.cs, EcommerceApp.Backend/Pages/Products/Edit.cshtml.cs

## 🔧 Technical Changes (Detailed)
Removed redundant category options from Create page, and populated category options only in the OnPost method of the Edit page. Moved ValidateAntiForgeryToken attribute to the correct position.

## ⚡ Impact
Reduced redundancy, improved code maintainability, and ensured correct validation.

