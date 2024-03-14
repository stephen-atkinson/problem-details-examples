const { ProblemDocument } = require('http-problem-details')
const { ErrorMapper } = require ('http-problem-details-mapper')
const NotFoundError = require('./not-found-error.js')
 
 
class NotFoundErrorMapper extends ErrorMapper {
  constructor() {
    super(NotFoundError)
  }
 
  mapError (error) {
    return new ProblemDocument({
      status: 404,
      title: 'Not Found',
      detail: error.message,
      type: 'https://tools.ietf.org/html/rfc9110#section-15.5.5',
      instance: error.url
    })
  }
}

module.exports = NotFoundErrorMapper