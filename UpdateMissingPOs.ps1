$xlsx = import-xlsx ./missing.xlsx
foreach ($missingPO in $xlsx)
{
	$missingPO
	@{Invoice=@{InvoiceId=$missingPO.InvoiceId;PONumber=$missingPO.PONumber}}|convertto-json|out-file uInvoice.json
	d8 UpdateInvoice -bodyFile uInvoice.json
}