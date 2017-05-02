import { GetPdfOnlinePage } from './app.po';

describe('get-pdf-online App', () => {
  let page: GetPdfOnlinePage;

  beforeEach(() => {
    page = new GetPdfOnlinePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
