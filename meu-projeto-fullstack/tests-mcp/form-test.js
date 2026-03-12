const { chromium } = require('playwright');

(async () => {
  const browser = await chromium.launch();
  const page = await browser.newPage();
  let alertMessage = null;
  page.on('dialog', dialog => {
    alertMessage = dialog.message();
    dialog.dismiss();
  });

  // log browser console to catch errors
  page.on('console', msg => {
    console.log('PAGE LOG:', msg.text());
  });

  // optional: track when POST appears
  page.on('request', request => {
    if (request.url().includes('/api/usuarios') && request.method() === 'POST') {
      console.log('POST request sent');
    }
  });

  // allow param for cep
  const cepToUse = process.argv[2] || '97015373';

  await page.goto('http://localhost:5173');
  // wait for the form to render
  await page.waitForSelector('.field');

  // Fill the form fields using CSS selectors in order (name, email)
  const fields = page.locator('.field');
  await fields.nth(0).locator('input').fill('Evandson Teste');
  await fields.nth(1).locator('input').fill('contato@evandson.dev');
  await page.fill('#cep-input', cepToUse);

  // Click the search button and wait briefly for rua value (timeout if none)
  await page.click('.btn-search');
  try {
    await page.waitForFunction(() => {
      const ruaInput = document.querySelector('input.readonly-field');
      return ruaInput && ruaInput.value.trim().length > 0;
    }, { timeout: 5000 });
  } catch (e) {
    console.log('Rua did not populate within timeout');
  }

  // Submit the form
  await page.click('text=Salvar no Banco');

  // wait a bit
  await page.waitForTimeout(2000);

  // read rua and log
  const rua = await page.locator('input.readonly-field').first().inputValue();
  console.log('Rua after lookup:', rua);
  console.log('Alert message:', alertMessage);
  await browser.close();
})();