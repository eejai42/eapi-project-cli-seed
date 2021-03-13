d8 getInvoices|convertfrom-json|select -expand Invoices|select *,PONumber|export-xlsx ./missing.xlsx -clearsheet
start ./missing.xlsx
