import { PrecizeSoft.GetPdfOnline.Web.NgAppPage } from './app.po';

describe('precize-soft.get-pdf-online.web.ng-app App', () => {
  let page: PrecizeSoft.GetPdfOnline.Web.NgAppPage;

  beforeEach(() => {
    page = new PrecizeSoft.GetPdfOnline.Web.NgAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
