## 📅 Feature Release (ChiragBaroliya/feature/7-dummy-data-insert) - 2026-04-07 07:03:27

## Features Implemented
Mock category data has been added to the MockCategoryStore, and seed products have been added to the MockProductStore. A new vendor user 'chirag' has been added to the MockUserStore.

## Bug Fixes
No bug fixes detected.

## Affected Modules / Layers
The affected modules are:
- MockCategoryStore
- MockProductStore
- MockUserStore

## Technical Changes (Detailed)
- A static constructor has been added to MockCategoryStore to seed dummy categories.
- A static constructor has been added to MockProductStore to seed dummy products.
- A new user 'chirag' with role 'Vendor' has been added to the MockUserStore.

## Impact
The addition of mock category data and seed products will allow for testing and demonstration of the application's functionality without requiring actual data. The new vendor user will provide an additional user account for testing purposes.

