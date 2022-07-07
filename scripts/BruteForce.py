import zipfile
import timeit
import sys

def crack(dictionary_attack, zFile, filename):

    attempts = 0
    flag = 0

    with open(dictionary_attack, 'r') as word:

        print("Started Cracking Password")

        for line in word:

            try:
                passwd = line.strip('\n')
                zFile.extractall(pwd=str.encode(passwd))

            except Exception:

                attempts += 1
                pass

            else:
                print("Password Brute Forced is %s" % (passwd))
                flag = 1
                break

        print("Attempted %d Passwords from %s Wordlist" % (attempts, filename))
        if flag == 0:
            print("Password Not in "+ str(filename))

def main():

    file_name=input("Enter Zip File name: ")
    dictionary_name=input("Enter Dictionary File name: ")
    zip_file = zipfile.ZipFile(str(file_name))
    start = timeit.default_timer()
    crack(dictionary_name, zip_file, file_name)
    stop = timeit.default_timer()
    print("Crack Password in %d Secs" % (stop - start))

if __name__ == "__main__":
    main()