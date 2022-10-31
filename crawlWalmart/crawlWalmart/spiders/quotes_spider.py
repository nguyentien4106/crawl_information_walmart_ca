import scrapy
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
import time
from selenium.webdriver.common.action_chains import ActionChains
class QuotesSpider(scrapy.Spider):
    name = "walmart"
    username = 'hadiddi@gmail.com'
    password = 'Alger153'

    def start_requests(self):
        urls = [
            'https://www.walmart.ca/en',
        ]
        for url in urls:
            yield scrapy.Request(url=url, callback=self.parse)
    def solveHuman(self, driver):
        driver.maximize_window()
            # /html/body/div/div/div[2]/div[2]/p
        element = driver.find_element(By.PARTIAL_LINK_TEXT, 'Press')
        action = ActionChains(driver)
        action.click_and_hold(element)
        action.perform()
        time.sleep(10)
        action.release(element)
        action.perform()
        time.sleep(0.2)
        action.release(element)

    def yeildToFile(self):
        pass
    def parse(self, response):
        PATH_EDGE_DRIVER = r"C:\Users\NguyenTien\OneDrive\Desktop\Freelance Project\chromedriver_win32\chromedriver.exe"
        # options = Options()
        # options.add_argument("start-maximized")
        # options.add_experimental_option("excludeSwitches", ["enable-automation"])
        # options.add_experimental_option('useAutomationExtension', False)
        # options.add_argument('--disable-blink-features=AutomationControlled')
        #
        # driver = webdriver.Chrome(PATH_EDGE_DRIVER, options=options)
        # driver.get("https://www.walmart.ca/en")
        # # dn db-hdkp relative div
        # signInButton = driver.find_element(By.XPATH, '/html/body/div[1]/div/div[2]/div/div[3]/div/div[2]/div[2]/div/div[2]/div/div[3]/div/span/a')
        # signInButton.click()
        #
        # # pass username and password
        # driver.find_element(By.ID, "username").send_keys(self.username)
        # driver.find_element(By.ID, "password").send_keys(self.password)
        #
        # # submit
        # driver.find_element(By.XPATH, '//*[@id="login-form"]/div/div[7]/button').click()
        #
        #
        # # Go to account setting
        # driver.find_element(By.XPATH, '/html/body/div[1]/div/div[2]/div/div[3]/div/div[2]/div[2]/div/div[2]/div/div[3]/div/span/a')
        #
        # # Click to profile setting
        # driver.find_element(By.XPATH, '//*[@id="accounts-home-page"]/div[3]/div[1]/div[4]/a[1]')
        #
        # #
        from selenium import webdriver
        from selenium_stealth import stealth
        import time

        options = webdriver.ChromeOptions()
        options.add_argument("start-maximized")

        # options.add_argument("--headless")

        options.add_experimental_option("excludeSwitches", ["enable-automation"])
        options.add_experimental_option('useAutomationExtension', False)
        driver = webdriver.Chrome(options=options,
                                  executable_path=PATH_EDGE_DRIVER)

        stealth(driver,
                languages=["en-US", "en"],
                vendor="Google Inc.",
                platform="Win32",
                webgl_vendor="Intel Inc.",
                renderer="Intel Iris OpenGL Engine",
                fix_hairline=True,
                )

        url = "https://www.walmart.ca/en"
        driver.get(url)

        # if len(driver.find_element(By.PARTIAL_LINK_TEXT, 'Press')) > 0:
        #     time.sleep(20)


        # click button sign in
        driver.find_element(By.CLASS_NAME, 'css-1xh2uh0').click()

        # Send keys
        driver.find_element(By.ID, "username").send_keys(self.username)
        driver.find_element(By.ID, "password").send_keys(self.password)

        # submit
        driver.find_element(By.CLASS_NAME, "css-vfxkzw ").click()

        time.sleep(10)
        driver.quit()
