# 🧪 Integration Testing Runbook & Bug Mitigation Log

**Project:** Campus Cart - Student Marketplace  
**Lead Engineer:** Charles Kingsley Ajeigbe (Testing & Support Context Verification)

---

## 🗺️ Cross-Functional Integration Test Cases

The following test suites validate the integration between **Faith's UI Design layouts**, **Anderson's DB Identity configuration**, and **Nico's & Stephen's CRUD services**:

### Test Suite 1: Cart Calculation & Quantity Validation

* **Objective:** Verify price totaling and quantity controls across page navigation states.
* **Procedures executed:** 1. Add an identical item multiple times via `ProductCard.razor`.
  2. Verify total item badge increments via `NavMenu.razor`.
  3. Navigate to `/cart` and manipulate input elements with extreme values (e.g., `0`, `-5`, `999`).
* **Expected Result Matrix:** Negative integers are rejected by input handlers; the summary subtotal recalculates instantly according to the formula: $Total = \sum (Price \times Quantity)$.

### Test Suite 2: Device Responsive Breakpoint Verification

* **Objective:** Confirm UI consistency under varied device widths (Mobile viewports).
* **Procedures executed:** Emulated layout dimensions inside inspection engine environments (375px to 1024px).
* **Expected Result Matrix:** The product display card list fluidly collapses into a single vertical sequence column layout on mobile screens without spilling over or overlapping the custom global footer variables.

---

## 📝 Documented Known System Quirks & Hotfixes

During the integration of multi-module features, our team discovered several environment exceptions. Below are their structural root causes and corresponding terminal workarounds:

### Bug 1: Binary Build Locks (MSB3021 / MSB3026)

* **Symptom:** The .NET build process fails with an exception stating `apphost.exe cannot copy to bin/... because the file is locked by another process.`
* **Root Cause:** A running background instance of the development web app remains stuck in execution loops within memory buffers.
* **Mitigation Workaround:** Terminate the rogue Process ID manually from the terminal environment:

  ```bash
  taskkill /F /IM Campus-Cart-Student-Marketplace.exe
